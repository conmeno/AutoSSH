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
            this.cbStartWindows = new System.Windows.Forms.CheckBox();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.txtListApp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btSaveAppstoIphone = new System.Windows.Forms.Button();
            this.lbIphone = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.clbApp = new System.Windows.Forms.CheckedListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btAddApp = new System.Windows.Forms.Button();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBundleID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.btSaveListIp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridlist)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(605, 435);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 3;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // gridlist
            // 
            this.gridlist.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gridlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.Action,
            this.Run});
            this.gridlist.Location = new System.Drawing.Point(194, 19);
            this.gridlist.Name = "gridlist";
            this.gridlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridlist.Size = new System.Drawing.Size(282, 320);
            this.gridlist.TabIndex = 19;
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
            this.Run.HeaderText = "Choose Apps";
            this.Run.Name = "Run";
            this.Run.Text = "Choose Apps";
            this.Run.Width = 70;
            // 
            // cbStartWindows
            // 
            this.cbStartWindows.AutoSize = true;
            this.cbStartWindows.Location = new System.Drawing.Point(507, 439);
            this.cbStartWindows.Name = "cbStartWindows";
            this.cbStartWindows.Size = new System.Drawing.Size(92, 17);
            this.cbStartWindows.TabIndex = 56;
            this.cbStartWindows.Text = "Start with Win";
            this.cbStartWindows.UseVisualStyleBackColor = true;
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Location = new System.Drawing.Point(436, 439);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(73, 17);
            this.cbAutoStart.TabIndex = 55;
            this.cbAutoStart.Text = "Auto Start";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            // 
            // txtListApp
            // 
            this.txtListApp.Location = new System.Drawing.Point(9, 102);
            this.txtListApp.Multiline = true;
            this.txtListApp.Name = "txtListApp";
            this.txtListApp.Size = new System.Drawing.Size(149, 219);
            this.txtListApp.TabIndex = 57;
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
            this.tabControl1.Location = new System.Drawing.Point(4, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 418);
            this.tabControl1.TabIndex = 59;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btSaveListIp);
            this.tabPage1.Controls.Add(this.btSaveAppstoIphone);
            this.tabPage1.Controls.Add(this.lbIphone);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.clbApp);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btAddApp);
            this.tabPage1.Controls.Add(this.txtAppName);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtBundleID);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtListApp);
            this.tabPage1.Controls.Add(this.gridlist);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btSaveAppstoIphone
            // 
            this.btSaveAppstoIphone.Location = new System.Drawing.Point(589, 21);
            this.btSaveAppstoIphone.Name = "btSaveAppstoIphone";
            this.btSaveAppstoIphone.Size = new System.Drawing.Size(75, 23);
            this.btSaveAppstoIphone.TabIndex = 60;
            this.btSaveAppstoIphone.Text = "Save";
            this.btSaveAppstoIphone.UseVisualStyleBackColor = true;
            // 
            // lbIphone
            // 
            this.lbIphone.AutoSize = true;
            this.lbIphone.Location = new System.Drawing.Point(533, 26);
            this.lbIphone.Name = "lbIphone";
            this.lbIphone.Size = new System.Drawing.Size(21, 13);
            this.lbIphone.TabIndex = 80;
            this.lbIphone.Text = "[ip]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(484, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "Iphone:";
            // 
            // clbApp
            // 
            this.clbApp.CheckOnClick = true;
            this.clbApp.FormattingEnabled = true;
            this.clbApp.Location = new System.Drawing.Point(482, 49);
            this.clbApp.Name = "clbApp";
            this.clbApp.Size = new System.Drawing.Size(182, 289);
            this.clbApp.TabIndex = 60;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(198, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "List Iphone:";
            // 
            // btAddApp
            // 
            this.btAddApp.Location = new System.Drawing.Point(63, 58);
            this.btAddApp.Name = "btAddApp";
            this.btAddApp.Size = new System.Drawing.Size(75, 23);
            this.btAddApp.TabIndex = 60;
            this.btAddApp.Text = "Add App";
            this.btAddApp.UseVisualStyleBackColor = true;
            this.btAddApp.Click += new System.EventHandler(this.btAddApp_Click);
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(63, 32);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(95, 20);
            this.txtAppName.TabIndex = 77;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 76;
            this.label10.Text = "App Name";
            // 
            // txtBundleID
            // 
            this.txtBundleID.Location = new System.Drawing.Point(63, 6);
            this.txtBundleID.Name = "txtBundleID";
            this.txtBundleID.Size = new System.Drawing.Size(95, 20);
            this.txtBundleID.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "BundleID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Apps";
            // 
            // tabPage2
            // 
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
            this.tabPage2.Size = new System.Drawing.Size(672, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Config";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDefaultIP
            // 
            this.txtDefaultIP.Location = new System.Drawing.Point(86, 159);
            this.txtDefaultIP.Name = "txtDefaultIP";
            this.txtDefaultIP.Size = new System.Drawing.Size(124, 20);
            this.txtDefaultIP.TabIndex = 75;
            this.txtDefaultIP.Text = "192.168.1.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Default IP";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(86, 133);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(124, 20);
            this.txtPassword.TabIndex = 73;
            this.txtPassword.Text = "alpine";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(86, 107);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(124, 20);
            this.txtUsername.TabIndex = 71;
            this.txtUsername.Text = "root";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "User name";
            // 
            // txtRespring
            // 
            this.txtRespring.Location = new System.Drawing.Point(86, 81);
            this.txtRespring.Name = "txtRespring";
            this.txtRespring.Size = new System.Drawing.Size(124, 20);
            this.txtRespring.TabIndex = 69;
            this.txtRespring.Text = "10000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Respring time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "AdPoint";
            // 
            // txtPointX
            // 
            this.txtPointX.Location = new System.Drawing.Point(71, 49);
            this.txtPointX.Name = "txtPointX";
            this.txtPointX.Size = new System.Drawing.Size(47, 20);
            this.txtPointX.TabIndex = 65;
            this.txtPointX.Text = "160";
            // 
            // txtPointY
            // 
            this.txtPointY.Location = new System.Drawing.Point(124, 49);
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
            this.txtSleep.Location = new System.Drawing.Point(67, 23);
            this.txtSleep.Name = "txtSleep";
            this.txtSleep.Size = new System.Drawing.Size(124, 20);
            this.txtSleep.TabIndex = 61;
            this.txtSleep.Text = "10000";
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.Location = new System.Drawing.Point(12, 185);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(75, 37);
            this.btSaveConfig.TabIndex = 60;
            this.btSaveConfig.Text = "Save Config";
            this.btSaveConfig.UseVisualStyleBackColor = true;
            this.btSaveConfig.Click += new System.EventHandler(this.btSaveConfig_Click);
            // 
            // btSaveListIp
            // 
            this.btSaveListIp.Location = new System.Drawing.Point(194, 345);
            this.btSaveListIp.Name = "btSaveListIp";
            this.btSaveListIp.Size = new System.Drawing.Size(75, 23);
            this.btSaveListIp.TabIndex = 81;
            this.btSaveListIp.Text = "Save List IP";
            this.btSaveListIp.UseVisualStyleBackColor = true;
            this.btSaveListIp.Click += new System.EventHandler(this.btSaveListIp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.DataGridView gridlist;
        private System.Windows.Forms.CheckBox cbStartWindows;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.TextBox txtListApp;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAddApp;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBundleID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox clbApp;
        private System.Windows.Forms.Button btSaveAppstoIphone;
        private System.Windows.Forms.Label lbIphone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewButtonColumn Run;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.Button btSaveListIp;
    }
}

