using Passwords;
using Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using VariableData;

namespace vPass
{

    public partial class Form1 : Form
    {

        #region Private Members
        LoginServer passLoginServer;
        Form selectionForm;
        StringBuilder strBuilder;
        string appMode;
        bool varPassFileAvailable;
        Stopwatch sW;

        MSGLogger msgLogger;
        #endregion

        #region constructor
        public Form1()
        {
            InitializeComponent();
            appMode = "generate";
            varPassFileAvailable = false;

            this.rndLoginPanel.Tag = typeof(VarRandomI);
            this.rndServerPanel.Tag = typeof(VarRandomI);
            this.timeLoginPanel.Tag = typeof(VarTime);
            this.timeServerPanel.Tag = typeof(VarTime);
            this.colorLoginPanel.Tag = typeof(VarColor);
            this.colorServerPanel.Tag = typeof(VarColor);
            this.captchaLoginPanel.Tag = typeof(VarRandomA);
            this.captchaServerPanel.Tag = typeof(VarRandomA);


            msgLogger = new MSGLogger(writeLog);

            sW = new Stopwatch();
            sW.Start();
            cmbVarPassType.Text = cmbVarPassType.Items[0].ToString();

            passLoginServer = new LoginServer(msgLogger);
            passLoginServer.initServer();
            passLoginServer.fillVarDataDisplay(this.grpGenerateData);
            passLoginServer.fillVarDataDisplay(this.grpQueryData);

            tabMain.TabPages[0].Select();
        }
        #endregion

        #region Private Methods
        private void writeLog(string strMessage)
        {
            TextBox tmpBox;
            if (appMode == "generate") tmpBox = txtLogGenerate;
            else tmpBox = txtLogLogin;
            tmpBox.AppendText(sW.Elapsed.Minutes + ":" + sW.Elapsed.Seconds + "." + sW.Elapsed.Milliseconds + "  " + strMessage + "\r\n");

        }

       

        private void addPassButton(PassElement passElement)
        {
            if (varPasswordPanel.Controls.Count > 0)
            {
                if (varPasswordPanel.Controls[varPasswordPanel.Controls.Count - 1].Name == "Fixanteil" && passElement.PassType == "Fixanteil")
                {
                    MessageBox.Show("Zwei Fixanteile hintereinander sind nicht möglich");
                    writeLog("Fehler: zwei gleiche Fixanteile nicht möglich");
                    return;
                }
            }
            Button passElementButton = new Button();
            passElementButton.AutoSize = true;
            passElementButton.Tag = passElement;
            passElementButton.Text = passElement.PassType;
            passElementButton.Name = passElement.PassType;
            varPasswordPanel.Controls.Add(passElementButton);
            passElementButton.Click += PassTypeButton_Click;
            passElement.parmsChanged += passParamsChanged;
            writeLog("neues Passwortelement " + passElement.PassType + " erstellt");
        }

        private void showPassParmSelection(PassElement pE)
        {
            string[] availableParms = pE.getAvailableParms();
            selectionForm = new Form();

            selectionForm.MaximizeBox = false;
            selectionForm.MinimizeBox = false;
            selectionForm.Text = pE.PassType;

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Font = new System.Drawing.Font(okButton.Font.FontFamily, 14);
            okButton.AutoSize = true;
            okButton.Tag = pE;
            okButton.Click += OkButton_Click;


            FlowLayoutPanel fLP = new FlowLayoutPanel();
            fLP.AutoSize = true;
            fLP.Name = "FLPanel";

            Control parmControl;

            if (availableParms.Length == 1 && availableParms[0] == "")
            {
                parmControl = new TextBox();
                parmControl.Width = 200;
                parmControl.Font = new System.Drawing.Font(parmControl.Font.FontFamily, 14);
            }
            else
            {
                parmControl = new ComboBox();
                parmControl.Width = 200;
                parmControl.Font = new System.Drawing.Font(parmControl.Font.FontFamily, 14);
                ((ComboBox)parmControl).DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (string item in availableParms)
                {
                    ((ComboBox)parmControl).Items.Add(item);
                }
            }
            parmControl.Name = "PassParmControl";
            selectionForm.Controls.Add(fLP);

            Label infoLabel = new Label();
            infoLabel.Text = "Für Zufallszahlenersetzung sind nur Buchstaben erlaubt,\n\r" +
                             "für Zufallsbuchstabenersetzung dementsprechend nur Zahlen\n\r"+
                              "Andere Zeichen werden gelöscht.\n\r" +
                              "Kleinbuchstaben werden durch Rückwärtsschreiben ihrer\n\rRepresentanten dargestellt";
            infoLabel.Top = fLP.Bottom;
            infoLabel.AutoSize = true;

            selectionForm.Controls.Add(infoLabel);

            ((FlowLayoutPanel)selectionForm.Controls["FLPanel"]).Controls.Add(parmControl);
            ((FlowLayoutPanel)selectionForm.Controls["FLPanel"]).Controls.Add(okButton);
            selectionForm.AutoSize = true;
            writeLog("Öffne Dialog für variable Passworteingabe: " + pE.PassType);
            selectionForm.ShowDialog();
        }

        private void refreshServerData()
        {
            passLoginServer.initServer();
            writeLog("Server neu initialisieren");
            passLoginServer.fillVarDataDisplay(this.grpQueryData);
            writeLog("Display auf der Abfragen-Seite mit Zufallsdaten füllen");
            passLoginServer.fillVarDataDisplay(this.grpGenerateData);
            writeLog("Display auf der Generieren-Seite mit Zufallsdaten füllen");
            if (passLoginServer.loadCheckPasswordFile()) varPassFileAvailable = true;
            else varPassFileAvailable = false;
        }

        #endregion

        #region Event Handler

        private void passParamsChanged(object sender, EventArgs e)
        {
            strBuilder = new StringBuilder();
            varPasswordResult.Text = "";
            passLoginServer.varPassword.clearElements();
            int i = 0;
            foreach (Button passElementBtn in this.varPasswordPanel.Controls)
            {
                PassElement tmpElement = (PassElement)passElementBtn.Tag;

                if ((PassElement)sender == tmpElement)
                {
                    if (tmpElement.PassParameter != "" && tmpElement.PassParameter != null)
                        passElementBtn.Text = tmpElement.PassCommand + ": " +
                        (tmpElement.GetType() == typeof(FixPassElement) ? tmpElement.getPassData() : tmpElement.PassParameter);
                    else
                        passElementBtn.Text = tmpElement.PassType;

                    writeLog("Parameter im Element " + i + " (" + tmpElement.PassType + ") geändert:" + tmpElement.PassParameter);
                }

                varPasswordResult.Text += tmpElement.getPassData();
                strBuilder.AppendLine(tmpElement.PassCommand + "(" + tmpElement.PassParameter + ")");
                passLoginServer.varPassword.addElement(new string[] { tmpElement.PassCommand, tmpElement.PassParameter });

                i++;
            }
            codeBox.Text = strBuilder.ToString();
            writeLog("Ergebnis aktualisiert");

        }

        private void PassTypeButton_Click(object sender, EventArgs e)
        {
            showPassParmSelection((PassElement)(((Button)sender).Tag));
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            PassElement tmpElement = (PassElement)((Button)sender).Tag;
            if (tmpElement.GetType() == typeof(FixPassElement))
                ((FixPassElement)tmpElement).FixPartRaw = ((FlowLayoutPanel)selectionForm.Controls["FLPanel"]).Controls["PassParmControl"].Text;
            else
                tmpElement.PassParameter = ((FlowLayoutPanel)selectionForm.Controls["FLPanel"]).Controls["PassParmControl"].Text;

            selectionForm.Close();
        }

        private void btnDynNumber_Click(object sender, EventArgs e)
        {
            switch (cmbVarPassType.Text)
            {
                case "Fixanteil":
                    addPassButton(new FixPassElement(new Dictionary<string, string>()));
                    break;
                case "Zufallszahlen(Zuordnungstabelle)":
                    addPassButton(new RandomIPassElement(passLoginServer.getServerData(typeof(VarRandomI))));
                    break;
                case "Zufallsbuchstaben(Captcha)":
                    addPassButton(new RandomAPassElement(passLoginServer.getServerData(typeof(VarRandomA))));
                    break;
                case "Zeit/Datum":
                    addPassButton(new TimedatePassElement(passLoginServer.getServerData(typeof(VarTime))));
                    break;
                case "Farbe":
                    addPassButton(new ColorPassElement(passLoginServer.getServerData(typeof(VarColor))));
                    break;
                default:
                    break;
            }

        }

        private void btnGenerateServerData_Click(object sender, EventArgs e)
        {
            if (!passLoginServer.generatePasswordFile()) MessageBox.Show("Zu wenig Elemente für ein Passwort");
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab.Text == "Passwort abfragen")
            {
                appMode = "query";
                if (!passLoginServer.varDataAvailable) passLoginServer.initServer();

                varPassFileAvailable = passLoginServer.loadCheckPasswordFile();

                if (varPassFileAvailable) passLoginServer.getDecryptedPasswordData(txtDatas);

                writeLog("Modus auf Abfrage gewechselt");
            }
            else
            {
                appMode = "generate";
                varPasswordPanel.Controls.Clear();
                this.passParamsChanged(this, new EventArgs());
                writeLog("Modus auf Generierung gewechselt");
                writeLog("Bestehende Inhalte zum Generieren eines Passworts gelöscht");
            }

        }

        private void btnRefreshServerData_Click(object sender, EventArgs e)
        {
            refreshServerData();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            varPassFileAvailable = passLoginServer.loadCheckPasswordFile();
            if (varPassFileAvailable) passLoginServer.getDecryptedPasswordData(txtDatas);
        }

        private void btnCheckPassword_Click(object sender, EventArgs e)
        {
            if (passLoginServer.checkPassword(txtLoginPassword.Text))
            {
                successPictBox.Image = Properties.Resources.juhu;
                pictTimer.Start();
                writeLog("Passwort wurde richtig eingegeben");
            }
            else
            {
                successPictBox.Image = Properties.Resources.puhh;
                writeLog("Passwort wurde falsch eingegeben");
                if (chkAutoReload.Checked)
                {
                    refreshServerData();
                    txtLoginPassword.Clear();
                }
                pictTimer.Start();
            }
        }

        private void pictTimer_Tick(object sender, EventArgs e)
        {
            successPictBox.Image = null;
            pictTimer.Stop();
        }
        #endregion


    }
}
