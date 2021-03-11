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
            this.btnDelete = new System.Windows.Forms.Button();
            this.varPasswordResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.varPasswordPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.grpGenerateData = new System.Windows.Forms.GroupBox();
            this.flowGeneratePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.btnGenerateServerData = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageGeneratePassword = new System.Windows.Forms.TabPage();
            this.trkImgSize = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPictSize = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLogGenerate = new System.Windows.Forms.TextBox();
            this.tabPageQueryPassword = new System.Windows.Forms.TabPage();
            this.btnRefreshServerData = new System.Windows.Forms.Button();
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
            this.timeLoginPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.grpGenerateData.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPageGeneratePassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkImgSize)).BeginInit();
            this.tabPageQueryPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.successPictBox)).BeginInit();
            this.grpQueryData.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDelete);
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
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(851, 65);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "letztes Element löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // varPasswordResult
            // 
            this.varPasswordResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.varPasswordResult.Location = new System.Drawing.Point(60, 67);
            this.varPasswordResult.Name = "varPasswordResult";
            this.varPasswordResult.ReadOnly = true;
            this.varPasswordResult.Size = new System.Drawing.Size(631, 20);
            this.varPasswordResult.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ergebnis";
            // 
            // varPasswordPanel
            // 
            this.varPasswordPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.varPasswordPanel.Location = new System.Drawing.Point(6, 19);
            this.varPasswordPanel.Name = "varPasswordPanel";
            this.varPasswordPanel.Size = new System.Drawing.Size(978, 35);
            this.varPasswordPanel.TabIndex = 0;
            // 
            // grpGenerateData
            // 
            this.grpGenerateData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGenerateData.Controls.Add(this.flowGeneratePanel);
            this.grpGenerateData.Location = new System.Drawing.Point(7, 116);
            this.grpGenerateData.Name = "grpGenerateData";
            this.grpGenerateData.Size = new System.Drawing.Size(989, 306);
            this.grpGenerateData.TabIndex = 4;
            this.grpGenerateData.TabStop = false;
            this.grpGenerateData.Text = "verfügbare Elemente (Doppleklick zum Hinzufügen)";
            // 
            // flowGeneratePanel
            // 
            this.flowGeneratePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowGeneratePanel.AutoScroll = true;
            this.flowGeneratePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.flowGeneratePanel.Location = new System.Drawing.Point(5, 19);
            this.flowGeneratePanel.Name = "flowGeneratePanel";
            this.flowGeneratePanel.Size = new System.Drawing.Size(978, 281);
            this.flowGeneratePanel.TabIndex = 1;
            // 
            // codeBox
            // 
            this.codeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.codeBox.Location = new System.Drawing.Point(7, 441);
            this.codeBox.Multiline = true;
            this.codeBox.Name = "codeBox";
            this.codeBox.ReadOnly = true;
            this.codeBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeBox.Size = new System.Drawing.Size(408, 126);
            this.codeBox.TabIndex = 6;
            this.codeBox.WordWrap = false;
            // 
            // btnGenerateServerData
            // 
            this.btnGenerateServerData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateServerData.Location = new System.Drawing.Point(860, 544);
            this.btnGenerateServerData.Name = "btnGenerateServerData";
            this.btnGenerateServerData.Size = new System.Drawing.Size(136, 23);
            this.btnGenerateServerData.TabIndex = 7;
            this.btnGenerateServerData.Text = "Passwortdatei generieren";
            this.btnGenerateServerData.UseVisualStyleBackColor = true;
            this.btnGenerateServerData.Click += new System.EventHandler(this.btnGenerateServerData_Click);
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tabPageGeneratePassword.Controls.Add(this.trkImgSize);
            this.tabPageGeneratePassword.Controls.Add(this.label13);
            this.tabPageGeneratePassword.Controls.Add(this.lblPictSize);
            this.tabPageGeneratePassword.Controls.Add(this.label12);
            this.tabPageGeneratePassword.Controls.Add(this.groupBox1);
            this.tabPageGeneratePassword.Controls.Add(this.txtLogGenerate);
            this.tabPageGeneratePassword.Controls.Add(this.btnGenerateServerData);
            this.tabPageGeneratePassword.Controls.Add(this.grpGenerateData);
            this.tabPageGeneratePassword.Controls.Add(this.codeBox);
            this.tabPageGeneratePassword.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneratePassword.Name = "tabPageGeneratePassword";
            this.tabPageGeneratePassword.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneratePassword.Size = new System.Drawing.Size(1004, 573);
            this.tabPageGeneratePassword.TabIndex = 0;
            this.tabPageGeneratePassword.Text = "Passwort anlegen";
            this.tabPageGeneratePassword.UseVisualStyleBackColor = true;
            // 
            // trkImgSize
            // 
            this.trkImgSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trkImgSize.Location = new System.Drawing.Point(871, 441);
            this.trkImgSize.Maximum = 100;
            this.trkImgSize.Minimum = 1;
            this.trkImgSize.Name = "trkImgSize";
            this.trkImgSize.Size = new System.Drawing.Size(119, 45);
            this.trkImgSize.TabIndex = 14;
            this.trkImgSize.Value = 50;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 425);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "variabler Passwort Code";
            // 
            // lblPictSize
            // 
            this.lblPictSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPictSize.AutoSize = true;
            this.lblPictSize.Location = new System.Drawing.Point(868, 425);
            this.lblPictSize.Name = "lblPictSize";
            this.lblPictSize.Size = new System.Drawing.Size(51, 13);
            this.lblPictSize.TabIndex = 13;
            this.lblPictSize.Text = "Bildgröße";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(431, 425);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Log:";
            // 
            // txtLogGenerate
            // 
            this.txtLogGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogGenerate.Location = new System.Drawing.Point(431, 441);
            this.txtLogGenerate.Multiline = true;
            this.txtLogGenerate.Name = "txtLogGenerate";
            this.txtLogGenerate.ReadOnly = true;
            this.txtLogGenerate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogGenerate.Size = new System.Drawing.Size(423, 126);
            this.txtLogGenerate.TabIndex = 12;
            this.txtLogGenerate.WordWrap = false;
            // 
            // tabPageQueryPassword
            // 
            this.tabPageQueryPassword.Controls.Add(this.btnRefreshServerData);
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
            // btnRefreshServerData
            // 
            this.btnRefreshServerData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshServerData.Location = new System.Drawing.Point(855, 311);
            this.btnRefreshServerData.Name = "btnRefreshServerData";
            this.btnRefreshServerData.Size = new System.Drawing.Size(143, 31);
            this.btnRefreshServerData.TabIndex = 5;
            this.btnRefreshServerData.Text = "Zufallsdaten erneuern";
            this.btnRefreshServerData.UseVisualStyleBackColor = true;
            this.btnRefreshServerData.Click += new System.EventHandler(this.btnRefreshServerData_Click);
            // 
            // chkAutoReload
            // 
            this.chkAutoReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoReload.AutoSize = true;
            this.chkAutoReload.Location = new System.Drawing.Point(279, 375);
            this.chkAutoReload.Name = "chkAutoReload";
            this.chkAutoReload.Size = new System.Drawing.Size(318, 17);
            this.chkAutoReload.TabIndex = 6;
            this.chkAutoReload.Text = "automatisches Erneuern der Zufallsdaten nach Falscheingabe";
            this.chkAutoReload.UseVisualStyleBackColor = true;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReadFile.Location = new System.Drawing.Point(285, 441);
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
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(480, 448);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Log:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 448);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Variable Daten entschlüsselt";
            // 
            // txtLogLogin
            // 
            this.txtLogLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogLogin.Location = new System.Drawing.Point(483, 464);
            this.txtLogLogin.Multiline = true;
            this.txtLogLogin.Name = "txtLogLogin";
            this.txtLogLogin.ReadOnly = true;
            this.txtLogLogin.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogLogin.Size = new System.Drawing.Size(506, 104);
            this.txtLogLogin.TabIndex = 10;
            // 
            // txtDatas
            // 
            this.txtDatas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDatas.Location = new System.Drawing.Point(13, 464);
            this.txtDatas.Multiline = true;
            this.txtDatas.Name = "txtDatas";
            this.txtDatas.ReadOnly = true;
            this.txtDatas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDatas.Size = new System.Drawing.Size(384, 104);
            this.txtDatas.TabIndex = 10;
            // 
            // successPictBox
            // 
            this.successPictBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.successPictBox.Location = new System.Drawing.Point(711, 369);
            this.successPictBox.Name = "successPictBox";
            this.successPictBox.Size = new System.Drawing.Size(116, 85);
            this.successPictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.successPictBox.TabIndex = 9;
            this.successPictBox.TabStop = false;
            // 
            // btnCheckPassword
            // 
            this.btnCheckPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckPassword.Location = new System.Drawing.Point(613, 398);
            this.btnCheckPassword.Name = "btnCheckPassword";
            this.btnCheckPassword.Size = new System.Drawing.Size(54, 22);
            this.btnCheckPassword.TabIndex = 8;
            this.btnCheckPassword.Text = "OK";
            this.btnCheckPassword.UseVisualStyleBackColor = true;
            this.btnCheckPassword.Click += new System.EventHandler(this.btnCheckPassword_Click);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLoginPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.Location = new System.Drawing.Point(13, 398);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(584, 22);
            this.txtLoginPassword.TabIndex = 7;
            this.txtLoginPassword.WordWrap = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 382);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Passwort eingeben:";
            // 
            // grpQueryData
            // 
            this.grpQueryData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpQueryData.Controls.Add(this.timeLoginPanel);
            this.grpQueryData.Location = new System.Drawing.Point(7, 6);
            this.grpQueryData.Name = "grpQueryData";
            this.grpQueryData.Size = new System.Drawing.Size(989, 299);
            this.grpQueryData.TabIndex = 5;
            this.grpQueryData.TabStop = false;
            this.grpQueryData.Text = "Daten vom Server";
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
            // pictTimer
            // 
            this.pictTimer.Interval = 2000;
            this.pictTimer.Tick += new System.EventHandler(this.pictTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 603);
            this.Controls.Add(this.tabMain);
            this.MinimumSize = new System.Drawing.Size(1030, 39);
            this.Name = "Form1";
            this.Text = "VarPasswordPrototyp";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpGenerateData.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPageGeneratePassword.ResumeLayout(false);
            this.tabPageGeneratePassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkImgSize)).EndInit();
            this.tabPageQueryPassword.ResumeLayout(false);
            this.tabPageQueryPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.successPictBox)).EndInit();
            this.grpQueryData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel varPasswordPanel;
        private System.Windows.Forms.TextBox varPasswordResult;
        private System.Windows.Forms.GroupBox grpGenerateData;
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
        private System.Windows.Forms.TableLayoutPanel timeLoginPanel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLogGenerate;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Timer pictTimer;
        private System.Windows.Forms.CheckBox chkAutoReload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.FlowLayoutPanel flowGeneratePanel;
        private System.Windows.Forms.TrackBar trkImgSize;
        private System.Windows.Forms.Label lblPictSize;
    }
}

