
using PassElements;
using Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vPass
{

    public partial class Form1 : Form
    {

        #region Private Members
        LoginServer passLoginServer;
        bool varPassFileAvailable;
        
        #endregion

        #region constructor
        public Form1()
        {
            InitializeComponent();
            varPassFileAvailable = false;
            passLoginServer = new LoginServer(this);
            passLoginServer.reloadVarDataDisplay();
            tabMain.TabPages[0].Select();
        }

        #endregion

        #region Private Methods
        
        

        //private void refreshServerData()
        //{
        //    passLoginServer.initServer();
        //    writeLog("Server neu initialisieren");
        //    passLoginServer.fillVarDataDisplay(this.grpQueryData);
        //    writeLog("Display auf der Abfragen-Seite mit Zufallsdaten füllen");
        //    passLoginServer.fillVarDataDisplay(this.grpGenerateData);
        //    writeLog("Display auf der Generieren-Seite mit Zufallsdaten füllen");
        //    if (passLoginServer.loadCheckPasswordFile()) varPassFileAvailable = true;
        //    else varPassFileAvailable = false;
        //}

        #endregion

        #region Event Handler
            
        private void btnGenerateServerData_Click(object sender, EventArgs e)
        {
            if (!passLoginServer.generatePasswordFile()) MessageBox.Show("Zu wenig Elemente für ein Passwort");
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab.Text == "Passwort abfragen")
            {
                flowGeneratePanel.Parent= (this.Controls.Find("grpQueryData", true))[0];
                trkImgSize.Parent= (this.Controls.Find("tabPageQueryPassword", true))[0];
                trkImgSize.Top -= 40;
                lblPictSize.Parent = (this.Controls.Find("tabPageQueryPassword", true))[0];
                lblPictSize.Top -= 40;
                passLoginServer.applicationMode = "query";
                varPassFileAvailable = passLoginServer.loadCheckPasswordFile();

                if (varPassFileAvailable) passLoginServer.getDecryptedPasswordData(txtDatas);
                
            }
            else
            {
                flowGeneratePanel.Parent = (this.Controls.Find("grpGenerateData", true))[0];
                trkImgSize.Parent = (this.Controls.Find("tabPageGeneratePassword", true))[0];
                trkImgSize.Top += 40;
                lblPictSize.Parent= (this.Controls.Find("tabPageGeneratePassword", true))[0];
                lblPictSize.Top += 40;
                passLoginServer.applicationMode = "generate";
                passLoginServer.initServer();
                passLoginServer.reloadVarDataDisplay();
            }

        }

        private void btnRefreshServerData_Click(object sender, EventArgs e)
        {
            passLoginServer.reloadVarDataDisplay();
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
            }
            else
            {
                successPictBox.Image = Properties.Resources.puhh;
                if (chkAutoReload.Checked)
                {
                    passLoginServer.reloadVarDataDisplay();
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
