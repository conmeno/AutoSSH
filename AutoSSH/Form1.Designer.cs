namespace AutoSSH
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btStart = new System.Windows.Forms.Button();
            this.gridlist = new System.Windows.Forms.DataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Run = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Script = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbStartWindows = new System.Windows.Forms.CheckBox();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ListIPCopy = new System.Windows.Forms.Button();
            this.txtListIP = new System.Windows.Forms.TextBox();
            this.btClearComand = new System.Windows.Forms.Button();
            this.btGenerateCommand = new System.Windows.Forms.Button();
            this.btSaveAppFromGrid = new System.Windows.Forms.Button();
            this.btSaveListIp = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.WaitKillPutty = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRoundResetIDFV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRoundClickAd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDefaultIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRespring = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPointX = new System.Windows.Forms.TextBox();
            this.txtPointY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSleep = new System.Windows.Forms.TextBox();
            this.btSaveConfig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridApps = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbClearCaches = new System.Windows.Forms.CheckBox();
            this.btGenBashScript = new System.Windows.Forms.Button();
            this.btCopyScript = new System.Windows.Forms.Button();
            this.btScriptPermission = new System.Windows.Forms.Button();
            this.btRespringAll = new System.Windows.Forms.Button();
            this.btHomeAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridlist)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaitKillPutty)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridApps)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.SystemColors.InfoText;
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStart.ForeColor = System.Drawing.SystemColors.Control;
            this.btStart.Location = new System.Drawing.Point(597, 432);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 42);
            this.btStart.TabIndex = 3;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // gridlist
            // 
            this.gridlist.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gridlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.Action,
            this.Run,
            this.Script});
            this.gridlist.Location = new System.Drawing.Point(122, 18);
            this.gridlist.Name = "gridlist";
            this.gridlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridlist.Size = new System.Drawing.Size(376, 320);
            this.gridlist.TabIndex = 19;
            this.gridlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridlist_CellContentClick);
            // 
            // IP
            // 
            this.IP.DataPropertyName = "IP";
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.Width = 50;
            // 
            // Action
            // 
            this.Action.DataPropertyName = "Apps";
            this.Action.HeaderText = "Apps";
            this.Action.Name = "Action";
            // 
            // Run
            // 
            this.Run.HeaderText = "Putty";
            this.Run.Name = "Run";
            this.Run.Text = "Putty";
            this.Run.Width = 70;
            // 
            // Script
            // 
            this.Script.HeaderText = "Script";
            this.Script.Name = "Script";
            this.Script.Text = "Script";
            // 
            // cbStartWindows
            // 
            this.cbStartWindows.AutoSize = true;
            this.cbStartWindows.Location = new System.Drawing.Point(80, 435);
            this.cbStartWindows.Name = "cbStartWindows";
            this.cbStartWindows.Size = new System.Drawing.Size(92, 17);
            this.cbStartWindows.TabIndex = 56;
            this.cbStartWindows.Text = "Start with Win";
            this.cbStartWindows.UseVisualStyleBackColor = true;
            this.cbStartWindows.CheckedChanged += new System.EventHandler(this.cbStartWindows_CheckedChanged);
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Location = new System.Drawing.Point(9, 435);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(73, 17);
            this.cbAutoStart.TabIndex = 55;
            this.cbAutoStart.Text = "Auto Start";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            this.cbAutoStart.CheckedChanged += new System.EventHandler(this.cbAutoStart_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(4, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 418);
            this.tabControl1.TabIndex = 59;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btHomeAll);
            this.tabPage1.Controls.Add(this.btRespringAll);
            this.tabPage1.Controls.Add(this.btScriptPermission);
            this.tabPage1.Controls.Add(this.btCopyScript);
            this.tabPage1.Controls.Add(this.btGenBashScript);
            this.tabPage1.Controls.Add(this.ListIPCopy);
            this.tabPage1.Controls.Add(this.txtListIP);
            this.tabPage1.Controls.Add(this.btClearComand);
            this.tabPage1.Controls.Add(this.btGenerateCommand);
            this.tabPage1.Controls.Add(this.btSaveListIp);
            this.tabPage1.Controls.Add(this.gridlist);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ListIPCopy
            // 
            this.ListIPCopy.Location = new System.Drawing.Point(15, 341);
            this.ListIPCopy.Name = "ListIPCopy";
            this.ListIPCopy.Size = new System.Drawing.Size(104, 39);
            this.ListIPCopy.TabIndex = 86;
            this.ListIPCopy.Text = "Copy List to IP List";
            this.ListIPCopy.UseVisualStyleBackColor = true;
            this.ListIPCopy.Click += new System.EventHandler(this.ListIPCopy_Click);
            // 
            // txtListIP
            // 
            this.txtListIP.Location = new System.Drawing.Point(15, 18);
            this.txtListIP.Multiline = true;
            this.txtListIP.Name = "txtListIP";
            this.txtListIP.Size = new System.Drawing.Size(104, 320);
            this.txtListIP.TabIndex = 85;
            // 
            // btClearComand
            // 
            this.btClearComand.Location = new System.Drawing.Point(504, 296);
            this.btClearComand.Name = "btClearComand";
            this.btClearComand.Size = new System.Drawing.Size(70, 42);
            this.btClearComand.TabIndex = 84;
            this.btClearComand.Text = "Clear Command";
            this.btClearComand.UseVisualStyleBackColor = true;
            this.btClearComand.Click += new System.EventHandler(this.btClearComand_Click);
            // 
            // btGenerateCommand
            // 
            this.btGenerateCommand.Location = new System.Drawing.Point(580, 296);
            this.btGenerateCommand.Name = "btGenerateCommand";
            this.btGenerateCommand.Size = new System.Drawing.Size(83, 42);
            this.btGenerateCommand.TabIndex = 83;
            this.btGenerateCommand.Text = "Gen Command";
            this.btGenerateCommand.UseVisualStyleBackColor = true;
            this.btGenerateCommand.Click += new System.EventHandler(this.btGenerateCommand_Click);
            // 
            // btSaveAppFromGrid
            // 
            this.btSaveAppFromGrid.Location = new System.Drawing.Point(553, 350);
            this.btSaveAppFromGrid.Name = "btSaveAppFromGrid";
            this.btSaveAppFromGrid.Size = new System.Drawing.Size(113, 36);
            this.btSaveAppFromGrid.TabIndex = 60;
            this.btSaveAppFromGrid.Text = "Save Apps";
            this.btSaveAppFromGrid.UseVisualStyleBackColor = true;
            this.btSaveAppFromGrid.Click += new System.EventHandler(this.btSaveAppFromGrid_Click);
            // 
            // btSaveListIp
            // 
            this.btSaveListIp.Location = new System.Drawing.Point(415, 344);
            this.btSaveListIp.Name = "btSaveListIp";
            this.btSaveListIp.Size = new System.Drawing.Size(83, 36);
            this.btSaveListIp.TabIndex = 81;
            this.btSaveListIp.Text = "Save List IP";
            this.btSaveListIp.UseVisualStyleBackColor = true;
            this.btSaveListIp.Click += new System.EventHandler(this.btSaveListIp_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.WaitKillPutty);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtRoundResetIDFV);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtRoundClickAd);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtDefaultIP);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtPassword);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtUsername);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtRespring);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtPointX);
            this.tabPage2.Controls.Add(this.txtPointY);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtSleep);
            this.tabPage2.Controls.Add(this.btSaveConfig);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(672, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Config";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WaitKillPutty
            // 
            this.WaitKillPutty.Location = new System.Drawing.Point(84, 48);
            this.WaitKillPutty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.WaitKillPutty.Name = "WaitKillPutty";
            this.WaitKillPutty.Size = new System.Drawing.Size(120, 20);
            this.WaitKillPutty.TabIndex = 82;
            this.WaitKillPutty.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 81;
            this.label9.Text = "Wait Kill Putty";
            // 
            // txtRoundResetIDFV
            // 
            this.txtRoundResetIDFV.Location = new System.Drawing.Point(107, 236);
            this.txtRoundResetIDFV.Name = "txtRoundResetIDFV";
            this.txtRoundResetIDFV.Size = new System.Drawing.Size(124, 20);
            this.txtRoundResetIDFV.TabIndex = 79;
            this.txtRoundResetIDFV.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 78;
            this.label4.Text = "RoundResetIDFV";
            // 
            // txtRoundClickAd
            // 
            this.txtRoundClickAd.Location = new System.Drawing.Point(87, 210);
            this.txtRoundClickAd.Name = "txtRoundClickAd";
            this.txtRoundClickAd.Size = new System.Drawing.Size(124, 20);
            this.txtRoundClickAd.TabIndex = 77;
            this.txtRoundClickAd.Text = "60";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 76;
            this.label13.Text = "RoundClickAd";
            // 
            // txtDefaultIP
            // 
            this.txtDefaultIP.Location = new System.Drawing.Point(87, 184);
            this.txtDefaultIP.Name = "txtDefaultIP";
            this.txtDefaultIP.Size = new System.Drawing.Size(124, 20);
            this.txtDefaultIP.TabIndex = 75;
            this.txtDefaultIP.Text = "192.168.1.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Default IP";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(87, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(124, 20);
            this.txtPassword.TabIndex = 73;
            this.txtPassword.Text = "alpine";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(87, 132);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(124, 20);
            this.txtUsername.TabIndex = 71;
            this.txtUsername.Text = "root";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "User name";
            // 
            // txtRespring
            // 
            this.txtRespring.Location = new System.Drawing.Point(87, 106);
            this.txtRespring.Name = "txtRespring";
            this.txtRespring.Size = new System.Drawing.Size(124, 20);
            this.txtRespring.TabIndex = 69;
            this.txtRespring.Text = "10000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Respring time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "AdPoint";
            // 
            // txtPointX
            // 
            this.txtPointX.Location = new System.Drawing.Point(72, 74);
            this.txtPointX.Name = "txtPointX";
            this.txtPointX.Size = new System.Drawing.Size(47, 20);
            this.txtPointX.TabIndex = 65;
            this.txtPointX.Text = "160";
            // 
            // txtPointY
            // 
            this.txtPointY.Location = new System.Drawing.Point(125, 74);
            this.txtPointY.Name = "txtPointY";
            this.txtPointY.Size = new System.Drawing.Size(47, 20);
            this.txtPointY.TabIndex = 64;
            this.txtPointY.Text = "220";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Sleep";
            // 
            // txtSleep
            // 
            this.txtSleep.Location = new System.Drawing.Point(84, 23);
            this.txtSleep.Name = "txtSleep";
            this.txtSleep.Size = new System.Drawing.Size(124, 20);
            this.txtSleep.TabIndex = 61;
            this.txtSleep.Text = "10000";
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.Location = new System.Drawing.Point(13, 256);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(75, 37);
            this.btSaveConfig.TabIndex = 60;
            this.btSaveConfig.Text = "Save Config";
            this.btSaveConfig.UseVisualStyleBackColor = true;
            this.btSaveConfig.Click += new System.EventHandler(this.btSaveConfig_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 39);
            this.button1.TabIndex = 84;
            this.button1.Text = "Force Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btReset
            // 
            this.btReset.BackColor = System.Drawing.SystemColors.InfoText;
            this.btReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReset.ForeColor = System.Drawing.SystemColors.Control;
            this.btReset.Location = new System.Drawing.Point(466, 433);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(125, 42);
            this.btReset.TabIndex = 85;
            this.btReset.Text = "ONLY RESET ";
            this.btReset.UseVisualStyleBackColor = false;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gridApps);
            this.tabPage3.Controls.Add(this.btSaveAppFromGrid);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(672, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Apps";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gridApps
            // 
            this.gridApps.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gridApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridApps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.AppName});
            this.gridApps.Location = new System.Drawing.Point(17, 9);
            this.gridApps.Name = "gridApps";
            this.gridApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridApps.Size = new System.Drawing.Size(647, 320);
            this.gridApps.TabIndex = 83;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BundleID";
            this.dataGridViewTextBoxColumn2.HeaderText = "BundleID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // AppName
            // 
            this.AppName.DataPropertyName = "AppName";
            this.AppName.HeaderText = "App Name";
            this.AppName.Name = "AppName";
            this.AppName.Width = 150;
            // 
            // cbClearCaches
            // 
            this.cbClearCaches.AutoSize = true;
            this.cbClearCaches.Location = new System.Drawing.Point(10, 458);
            this.cbClearCaches.Name = "cbClearCaches";
            this.cbClearCaches.Size = new System.Drawing.Size(89, 17);
            this.cbClearCaches.TabIndex = 86;
            this.cbClearCaches.Text = "Clear Caches";
            this.cbClearCaches.UseVisualStyleBackColor = true;
            // 
            // btGenBashScript
            // 
            this.btGenBashScript.Location = new System.Drawing.Point(505, 18);
            this.btGenBashScript.Name = "btGenBashScript";
            this.btGenBashScript.Size = new System.Drawing.Size(159, 42);
            this.btGenBashScript.TabIndex = 87;
            this.btGenBashScript.Text = "Gen Bash Script";
            this.btGenBashScript.UseVisualStyleBackColor = true;
            this.btGenBashScript.Click += new System.EventHandler(this.btGenBashScript_Click);
            // 
            // btCopyScript
            // 
            this.btCopyScript.Location = new System.Drawing.Point(505, 66);
            this.btCopyScript.Name = "btCopyScript";
            this.btCopyScript.Size = new System.Drawing.Size(159, 42);
            this.btCopyScript.TabIndex = 88;
            this.btCopyScript.Text = "Copy Script to Phone";
            this.btCopyScript.UseVisualStyleBackColor = true;
            this.btCopyScript.Click += new System.EventHandler(this.btCopyScript_Click);
            // 
            // btScriptPermission
            // 
            this.btScriptPermission.Location = new System.Drawing.Point(505, 114);
            this.btScriptPermission.Name = "btScriptPermission";
            this.btScriptPermission.Size = new System.Drawing.Size(159, 42);
            this.btScriptPermission.TabIndex = 89;
            this.btScriptPermission.Text = "Set Script Permission";
            this.btScriptPermission.UseVisualStyleBackColor = true;
            this.btScriptPermission.Click += new System.EventHandler(this.btScriptPermission_Click);
            // 
            // btRespringAll
            // 
            this.btRespringAll.Location = new System.Drawing.Point(504, 162);
            this.btRespringAll.Name = "btRespringAll";
            this.btRespringAll.Size = new System.Drawing.Size(159, 42);
            this.btRespringAll.TabIndex = 90;
            this.btRespringAll.Text = "Respring All";
            this.btRespringAll.UseVisualStyleBackColor = true;
            this.btRespringAll.Click += new System.EventHandler(this.btRespringAll_Click);
            // 
            // btHomeAll
            // 
            this.btHomeAll.Location = new System.Drawing.Point(504, 210);
            this.btHomeAll.Name = "btHomeAll";
            this.btHomeAll.Size = new System.Drawing.Size(159, 42);
            this.btHomeAll.TabIndex = 91;
            this.btHomeAll.Text = "Home Button All";
            this.btHomeAll.UseVisualStyleBackColor = true;
            this.btHomeAll.Click += new System.EventHandler(this.btHomeAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 478);
            this.Controls.Add(this.cbClearCaches);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbStartWindows);
            this.Controls.Add(this.cbAutoStart);
            this.Controls.Add(this.btStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridlist)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaitKillPutty)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridApps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.DataGridView gridlist;
        private System.Windows.Forms.CheckBox cbStartWindows;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSleep;
        private System.Windows.Forms.Button btSaveConfig;
        private System.Windows.Forms.TextBox txtPointX;
        private System.Windows.Forms.TextBox txtPointY;
        private System.Windows.Forms.TextBox txtDefaultIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRespring;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSaveListIp;
        private System.Windows.Forms.Button btSaveAppFromGrid;
        private System.Windows.Forms.TextBox txtRoundClickAd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btGenerateCommand;
        private System.Windows.Forms.TextBox txtRoundResetIDFV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown WaitKillPutty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btClearComand;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Button ListIPCopy;
        private System.Windows.Forms.TextBox txtListIP;
        private System.Windows.Forms.DataGridViewButtonColumn Script;
        private System.Windows.Forms.DataGridViewButtonColumn Run;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView gridApps;
        private System.Windows.Forms.CheckBox cbClearCaches;
        private System.Windows.Forms.Button btGenBashScript;
        private System.Windows.Forms.Button btCopyScript;
        private System.Windows.Forms.Button btScriptPermission;
        private System.Windows.Forms.Button btHomeAll;
        private System.Windows.Forms.Button btRespringAll;
    }
}

