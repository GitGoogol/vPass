namespace vPass
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.varPasswordResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.varPasswordPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDynNumber = new System.Windows.Forms.Button();
            this.grpGenerateData = new System.Windows.Forms.GroupBox();
            this.captchaServerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.colorServerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.timeServerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rndServerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVarPassType = new System.Windows.Forms.ComboBox();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.btnGenerateServerData = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageGeneratePassword = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLogGenerate = new System.Windows.Forms.TextBox();
            this.tabPageQueryPassword = new System.Windows.Forms.TabPage();
            this.chkAutoReload = new System.Windows.Forms.CheckBox();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLogLogin = new System.Windows.Forms.TextBox();
            this.txtDatas = new System.Windows.Forms.TextBox();
            this.successPictBox = new System.Windows.Forms.PictureBox();
            this.btnCheckPassword = new System.Windows.Forms.Button();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpQueryData = new System.Windows.Forms.GroupBox();
            this.btnRefreshServerData = new System.Windows.Forms.Button();
            this.captchaLoginPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.colorLoginPanel = new System.Windows.Forms.TableLayoutPanel();
            this.timeLoginPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rndLoginPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.grpGenerateData.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPageGeneratePassword.SuspendLayout();
            this.tabPageQueryPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.successPictBox)).BeginInit();
            this.grpQueryData.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.varPasswordResult);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.varPasswordPanel);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(990, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "variables Passwort";
            // 
            // varPasswordResult
            // 
            this.varPasswordResult.Location = new System.Drawing.Point(60, 67);
            this.varPasswordResult.Name = "varPasswordResult";
            this.varPasswordResult.ReadOnly = true;
            this.varPasswordResult.Size = new System.Drawing.Size(924, 20);
            this.varPasswordResult.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ergebnis";
            // 
            // varPasswordPanel
            // 
            this.varPasswordPanel.Location = new System.Drawing.Point(6, 19);
            this.varPasswordPanel.Name = "varPasswordPanel";
            this.varPasswordPanel.Size = new System.Drawing.Size(978, 35);
            this.varPasswordPanel.TabIndex = 0;
            // 
            // btnDynNumber
            // 
            this.btnDynNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDynNumber.Location = new System.Drawing.Point(7, 113);
            this.btnDynNumber.Name = "btnDynNumber";
            this.btnDynNumber.Size = new System.Drawing.Size(178, 24);
            this.btnDynNumber.TabIndex = 2;
            this.btnDynNumber.Text = "Passwortelement hinzufügen";
            this.btnDynNumber.UseVisualStyleBackColor = true;
            this.btnDynNumber.Click += new System.EventHandler(this.btnDynNumber_Click);
            // 
            // grpGenerateData
            // 
            this.grpGenerateData.Controls.Add(this.captchaServerPanel);
            this.grpGenerateData.Controls.Add(this.colorServerPanel);
            this.grpGenerateData.Controls.Add(this.timeServerPanel);
            this.grpGenerateData.Controls.Add(this.rndServerPanel);
            this.grpGenerateData.Controls.Add(this.label10);
            this.grpGenerateData.Controls.Add(this.label6);
            this.grpGenerateData.Controls.Add(this.label5);
            this.grpGenerateData.Controls.Add(this.label4);
            this.grpGenerateData.Location = new System.Drawing.Point(7, 365);
            this.grpGenerateData.Name = "grpGenerateData";
            this.grpGenerateData.Size = new System.Drawing.Size(989, 204);
            this.grpGenerateData.TabIndex = 4;
            this.grpGenerateData.TabStop = false;
            this.grpGenerateData.Text = "Beispiel Login Ansicht";
            // 
            // captchaServerPanel
            // 
            this.captchaServerPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.captchaServerPanel.ColumnCount = 10;
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaServerPanel.Location = new System.Drawing.Point(396, 122);
            this.captchaServerPanel.Name = "captchaServerPanel";
            this.captchaServerPanel.RowCount = 2;
            this.captchaServerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.captchaServerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.captchaServerPanel.Size = new System.Drawing.Size(0, 57);
            this.captchaServerPanel.TabIndex = 4;
            // 
            // colorServerPanel
            // 
            this.colorServerPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.colorServerPanel.ColumnCount = 5;
            this.colorServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorServerPanel.Location = new System.Drawing.Point(727, 45);
            this.colorServerPanel.Name = "colorServerPanel";
            this.colorServerPanel.RowCount = 2;
            this.colorServerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.colorServerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.colorServerPanel.Size = new System.Drawing.Size(0, 38);
            this.colorServerPanel.TabIndex = 4;
            // 
            // timeServerPanel
            // 
            this.timeServerPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.timeServerPanel.ColumnCount = 7;
            this.timeServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeServerPanel.Location = new System.Drawing.Point(9, 122);
            this.timeServerPanel.Name = "timeServerPanel";
            this.timeServerPanel.RowCount = 2;
            this.timeServerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeServerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeServerPanel.Size = new System.Drawing.Size(0, 38);
            this.timeServerPanel.TabIndex = 4;
            // 
            // rndServerPanel
            // 
            this.rndServerPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.rndServerPanel.ColumnCount = 26;
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndServerPanel.Location = new System.Drawing.Point(9, 42);
            this.rndServerPanel.Name = "rndServerPanel";
            this.rndServerPanel.RowCount = 2;
            this.rndServerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rndServerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rndServerPanel.Size = new System.Drawing.Size(0, 41);
            this.rndServerPanel.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(393, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Zufallsbuchstaben";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(724, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Farbe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Zeit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Zufallszahl";
            // 
            // cmbVarPassType
            // 
            this.cmbVarPassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVarPassType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVarPassType.FormattingEnabled = true;
            this.cmbVarPassType.Items.AddRange(new object[] {
            "Fixanteil",
            "Zufallszahlen(Zuordnungstabelle)",
            "Zufallsbuchstaben(Captcha)",
            "Zeit/Datum",
            "Farbe"});
            this.cmbVarPassType.Location = new System.Drawing.Point(200, 113);
            this.cmbVarPassType.Name = "cmbVarPassType";
            this.cmbVarPassType.Size = new System.Drawing.Size(215, 24);
            this.cmbVarPassType.TabIndex = 5;
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(7, 166);
            this.codeBox.Multiline = true;
            this.codeBox.Name = "codeBox";
            this.codeBox.ReadOnly = true;
            this.codeBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeBox.Size = new System.Drawing.Size(408, 183);
            this.codeBox.TabIndex = 6;
            this.codeBox.WordWrap = false;
            // 
            // btnGenerateServerData
            // 
            this.btnGenerateServerData.Location = new System.Drawing.Point(854, 326);
            this.btnGenerateServerData.Name = "btnGenerateServerData";
            this.btnGenerateServerData.Size = new System.Drawing.Size(136, 23);
            this.btnGenerateServerData.TabIndex = 7;
            this.btnGenerateServerData.Text = "Passwortdatei generieren";
            this.btnGenerateServerData.UseVisualStyleBackColor = true;
            this.btnGenerateServerData.Click += new System.EventHandler(this.btnGenerateServerData_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageGeneratePassword);
            this.tabMain.Controls.Add(this.tabPageQueryPassword);
            this.tabMain.Location = new System.Drawing.Point(1, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1012, 599);
            this.tabMain.TabIndex = 8;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPageGeneratePassword
            // 
            this.tabPageGeneratePassword.Controls.Add(this.label13);
            this.tabPageGeneratePassword.Controls.Add(this.label12);
            this.tabPageGeneratePassword.Controls.Add(this.txtLogGenerate);
            this.tabPageGeneratePassword.Controls.Add(this.groupBox1);
            this.tabPageGeneratePassword.Controls.Add(this.btnGenerateServerData);
            this.tabPageGeneratePassword.Controls.Add(this.btnDynNumber);
            this.tabPageGeneratePassword.Controls.Add(this.codeBox);
            this.tabPageGeneratePassword.Controls.Add(this.grpGenerateData);
            this.tabPageGeneratePassword.Controls.Add(this.cmbVarPassType);
            this.tabPageGeneratePassword.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneratePassword.Name = "tabPageGeneratePassword";
            this.tabPageGeneratePassword.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneratePassword.Size = new System.Drawing.Size(1004, 573);
            this.tabPageGeneratePassword.TabIndex = 0;
            this.tabPageGeneratePassword.Text = "Passwort anlegen";
            this.tabPageGeneratePassword.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "variabler Passwort Code";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(460, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Log:";
            // 
            // txtLogGenerate
            // 
            this.txtLogGenerate.Location = new System.Drawing.Point(463, 127);
            this.txtLogGenerate.Multiline = true;
            this.txtLogGenerate.Name = "txtLogGenerate";
            this.txtLogGenerate.ReadOnly = true;
            this.txtLogGenerate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogGenerate.Size = new System.Drawing.Size(376, 222);
            this.txtLogGenerate.TabIndex = 12;
            this.txtLogGenerate.WordWrap = false;
            // 
            // tabPageQueryPassword
            // 
            this.tabPageQueryPassword.Controls.Add(this.chkAutoReload);
            this.tabPageQueryPassword.Controls.Add(this.btnReadFile);
            this.tabPageQueryPassword.Controls.Add(this.label11);
            this.tabPageQueryPassword.Controls.Add(this.label9);
            this.tabPageQueryPassword.Controls.Add(this.txtLogLogin);
            this.tabPageQueryPassword.Controls.Add(this.txtDatas);
            this.tabPageQueryPassword.Controls.Add(this.successPictBox);
            this.tabPageQueryPassword.Controls.Add(this.btnCheckPassword);
            this.tabPageQueryPassword.Controls.Add(this.txtLoginPassword);
            this.tabPageQueryPassword.Controls.Add(this.label8);
            this.tabPageQueryPassword.Controls.Add(this.grpQueryData);
            this.tabPageQueryPassword.Location = new System.Drawing.Point(4, 22);
            this.tabPageQueryPassword.Name = "tabPageQueryPassword";
            this.tabPageQueryPassword.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQueryPassword.Size = new System.Drawing.Size(1004, 573);
            this.tabPageQueryPassword.TabIndex = 1;
            this.tabPageQueryPassword.Text = "Passwort abfragen";
            this.tabPageQueryPassword.UseVisualStyleBackColor = true;
            // 
            // chkAutoReload
            // 
            this.chkAutoReload.AutoSize = true;
            this.chkAutoReload.Location = new System.Drawing.Point(279, 234);
            this.chkAutoReload.Name = "chkAutoReload";
            this.chkAutoReload.Size = new System.Drawing.Size(318, 17);
            this.chkAutoReload.TabIndex = 6;
            this.chkAutoReload.Text = "automatisches Erneuern der Zufallsdaten nach Falscheingabe";
            this.chkAutoReload.UseVisualStyleBackColor = true;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(284, 295);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(112, 20);
            this.btnReadFile.TabIndex = 12;
            this.btnReadFile.TabStop = false;
            this.btnReadFile.Text = "Daten neu einlesen";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(480, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Log:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 303);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Variable Daten entschlüsselt";
            // 
            // txtLogLogin
            // 
            this.txtLogLogin.Location = new System.Drawing.Point(483, 319);
            this.txtLogLogin.Multiline = true;
            this.txtLogLogin.Name = "txtLogLogin";
            this.txtLogLogin.ReadOnly = true;
            this.txtLogLogin.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogLogin.Size = new System.Drawing.Size(506, 233);
            this.txtLogLogin.TabIndex = 10;
            // 
            // txtDatas
            // 
            this.txtDatas.Location = new System.Drawing.Point(13, 319);
            this.txtDatas.Multiline = true;
            this.txtDatas.Name = "txtDatas";
            this.txtDatas.ReadOnly = true;
            this.txtDatas.Size = new System.Drawing.Size(384, 233);
            this.txtDatas.TabIndex = 10;
            // 
            // successPictBox
            // 
            this.successPictBox.Location = new System.Drawing.Point(711, 228);
            this.successPictBox.Name = "successPictBox";
            this.successPictBox.Size = new System.Drawing.Size(116, 85);
            this.successPictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.successPictBox.TabIndex = 9;
            this.successPictBox.TabStop = false;
            // 
            // btnCheckPassword
            // 
            this.btnCheckPassword.Location = new System.Drawing.Point(613, 257);
            this.btnCheckPassword.Name = "btnCheckPassword";
            this.btnCheckPassword.Size = new System.Drawing.Size(54, 22);
            this.btnCheckPassword.TabIndex = 8;
            this.btnCheckPassword.Text = "OK";
            this.btnCheckPassword.UseVisualStyleBackColor = true;
            this.btnCheckPassword.Click += new System.EventHandler(this.btnCheckPassword_Click);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.Location = new System.Drawing.Point(13, 257);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(584, 22);
            this.txtLoginPassword.TabIndex = 7;
            this.txtLoginPassword.WordWrap = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Passwort eingeben:";
            // 
            // grpQueryData
            // 
            this.grpQueryData.Controls.Add(this.btnRefreshServerData);
            this.grpQueryData.Controls.Add(this.captchaLoginPanel);
            this.grpQueryData.Controls.Add(this.label14);
            this.grpQueryData.Controls.Add(this.colorLoginPanel);
            this.grpQueryData.Controls.Add(this.timeLoginPanel);
            this.grpQueryData.Controls.Add(this.rndLoginPanel);
            this.grpQueryData.Controls.Add(this.label2);
            this.grpQueryData.Controls.Add(this.label3);
            this.grpQueryData.Controls.Add(this.label7);
            this.grpQueryData.Location = new System.Drawing.Point(7, 6);
            this.grpQueryData.Name = "grpQueryData";
            this.grpQueryData.Size = new System.Drawing.Size(989, 216);
            this.grpQueryData.TabIndex = 5;
            this.grpQueryData.TabStop = false;
            this.grpQueryData.Text = "Daten vom Server";
            // 
            // btnRefreshServerData
            // 
            this.btnRefreshServerData.Location = new System.Drawing.Point(6, 170);
            this.btnRefreshServerData.Name = "btnRefreshServerData";
            this.btnRefreshServerData.Size = new System.Drawing.Size(143, 31);
            this.btnRefreshServerData.TabIndex = 5;
            this.btnRefreshServerData.Text = "Zufallsdaten erneuern";
            this.btnRefreshServerData.UseVisualStyleBackColor = true;
            this.btnRefreshServerData.Click += new System.EventHandler(this.btnRefreshServerData_Click);
            // 
            // captchaLoginPanel
            // 
            this.captchaLoginPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.captchaLoginPanel.ColumnCount = 10;
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.captchaLoginPanel.Location = new System.Drawing.Point(393, 103);
            this.captchaLoginPanel.Name = "captchaLoginPanel";
            this.captchaLoginPanel.RowCount = 2;
            this.captchaLoginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.captchaLoginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.captchaLoginPanel.Size = new System.Drawing.Size(0, 57);
            this.captchaLoginPanel.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(390, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Zufallsbuchstaben";
            // 
            // colorLoginPanel
            // 
            this.colorLoginPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.colorLoginPanel.ColumnCount = 5;
            this.colorLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.colorLoginPanel.Location = new System.Drawing.Point(768, 37);
            this.colorLoginPanel.Name = "colorLoginPanel";
            this.colorLoginPanel.RowCount = 2;
            this.colorLoginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.colorLoginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.colorLoginPanel.Size = new System.Drawing.Size(0, 38);
            this.colorLoginPanel.TabIndex = 4;
            // 
            // timeLoginPanel
            // 
            this.timeLoginPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.timeLoginPanel.ColumnCount = 7;
            this.timeLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.timeLoginPanel.Location = new System.Drawing.Point(9, 103);
            this.timeLoginPanel.Name = "timeLoginPanel";
            this.timeLoginPanel.RowCount = 2;
            this.timeLoginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeLoginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.timeLoginPanel.Size = new System.Drawing.Size(0, 38);
            this.timeLoginPanel.TabIndex = 4;
            // 
            // rndLoginPanel
            // 
            this.rndLoginPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.rndLoginPanel.ColumnCount = 26;
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rndLoginPanel.Location = new System.Drawing.Point(9, 37);
            this.rndLoginPanel.Name = "rndLoginPanel";
            this.rndLoginPanel.RowCount = 2;
            this.rndLoginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rndLoginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rndLoginPanel.Size = new System.Drawing.Size(0, 41);
            this.rndLoginPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(765, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Farbe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Zeit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Zufallszahl";
            // 
            // pictTimer
            // 
            this.pictTimer.Interval = 2000;
            this.pictTimer.Tick += new System.EventHandler(this.pictTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 607);
            this.Controls.Add(this.tabMain);
            this.Name = "Form1";
            this.Text = "VarPasswordPrototyp";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpGenerateData.ResumeLayout(false);
            this.grpGenerateData.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPageGeneratePassword.ResumeLayout(false);
            this.tabPageGeneratePassword.PerformLayout();
            this.tabPageQueryPassword.ResumeLayout(false);
            this.tabPageQueryPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.successPictBox)).EndInit();
            this.grpQueryData.ResumeLayout(false);
            this.grpQueryData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel varPasswordPanel;
        private System.Windows.Forms.Button btnDynNumber;
        private System.Windows.Forms.TextBox varPasswordResult;
        private System.Windows.Forms.GroupBox grpGenerateData;
        private System.Windows.Forms.TableLayoutPanel colorServerPanel;
        private System.Windows.Forms.TableLayoutPanel timeServerPanel;
        private System.Windows.Forms.TableLayoutPanel rndServerPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVarPassType;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.Button btnGenerateServerData;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageGeneratePassword;
        private System.Windows.Forms.TabPage tabPageQueryPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLogLogin;
        private System.Windows.Forms.TextBox txtDatas;
        private System.Windows.Forms.PictureBox successPictBox;
        private System.Windows.Forms.Button btnCheckPassword;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpQueryData;
        private System.Windows.Forms.Button btnRefreshServerData;
        private System.Windows.Forms.TableLayoutPanel colorLoginPanel;
        private System.Windows.Forms.TableLayoutPanel timeLoginPanel;
        private System.Windows.Forms.TableLayoutPanel rndLoginPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLogGenerate;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Timer pictTimer;
        private System.Windows.Forms.CheckBox chkAutoReload;
        private System.Windows.Forms.TableLayoutPanel captchaServerPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel captchaLoginPanel;
        private System.Windows.Forms.Label label14;
    }
}

