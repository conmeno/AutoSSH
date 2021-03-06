﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSSH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<App> Apps = new List<App>();
        private void btStart_Click(object sender, EventArgs e)
        {
            RunAutoGame();

        }
        public void RunAutoGame()
        {

            List<Iphone> iphones = GetListIPFromGrid();
            //if (iphones != null)
            //{
            //    Parallel.ForEach(iphones, iphone =>
            //    { 
            //        string[] appstr = iphone.Apps.Split(',');

            //        string[] appBundleID = new string[appstr.Length];
            //        for (int i = 0; i < appstr.Length; i++)
            //        {
            //            int AppID = int.Parse(appstr[i]);
            //            App app = new App();
            //            app = (App)Apps.Where(a => a.ID == AppID).FirstOrDefault();
            //            appBundleID[i] = app.BundleID;
            //        }

            //        openApp(iphone, appBundleID);



            //    }
            //);


            foreach (var item in iphones)
            {
                string[] appstr = item.Apps.Split(',');

                string[] appBundleID = new string[appstr.Length];
                for (int i = 0; i < appstr.Length; i++)
                {
                    int AppID = int.Parse(appstr[i]);
                    App app = new App();
                    app = (App)Apps.Where(a => a.ID == AppID).FirstOrDefault();
                    appBundleID[i] = app.BundleID;
                }

                Thread thread = new Thread(() => openApp(item, appBundleID));
                thread.Start();


            }


        }



        public List<Iphone> GetListIPFromGrid()
        {
            List<Iphone> realList = new List<Iphone>();
            BindingList<Iphone> listIP = (BindingList<Iphone>)gridlist.DataSource;
            foreach (var item in listIP)
            {
                if (item.Select)
                {
                    realList.Add(item);
                }
            }
            return realList;
        }
        public void openApp(Iphone iphone, string[] apps)
        {

            Random rnd = new Random();
            string commandFile = "commands\\" + apps[rnd.Next(0, apps.Length)];
            iphone.OpenNumber += 1;
            if (iphone.OpenNumber % Config.iConfig.RoundResetIDFV == 0)
            {
                //reset idfa,idfv
                commandFile = commandFile + "-reset";
            }
            else if (iphone.OpenNumber % Config.iConfig.RoundClickAd == 0)
            {
                commandFile = "click-ad";
            }
            Process p = new Process();
            OpenPutty(Config.iConfig.DefaultIP + iphone.IP, commandFile + ".txt", ref p);
            System.Threading.Thread.Sleep(Config.iConfig.WaitKillPutty);
            //Process[] p = Process.GetProcessesByName("putty");
            try
            {
                p.Kill();
                //if (p != null)
                //{
                //    foreach (Process item in p)
                //    {

                //        //item.Kill();
                //    }
                //}
            }
            catch
            {
            }
            openApp(iphone, apps);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFirst();


            //  OpenPutty("192.168.1.140", "command2.txt");
        }


        public void LoadIphoneGrid()
        {
            gridlist.DataSource = Utility.LoadIPListBind();
            
        }
        public void LoadFirst()
        {
            Utility.LoadConfig();
            LoadIphoneGrid();
            LoadConfigtoForm();
            LoadListAppsToForm();
            starWithWindows();
            Apps = Utility.LoadApps();
            if (Config.iConfig.AutoStart)
            {
                RunAutoGame();
            }
        }

        public void LoadListAppsToForm()
        {
            gridApps.DataSource = Utility.LoadListAppstoGrid();
        }

        public void OpenPutty(string IP, string command, ref Process p)
        {
            try
            {
                string path = @"putty.exe";

                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.ErrorDialog = false;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.RedirectStandardError = false;
                p.EnableRaisingEvents = true;

                p.StartInfo.Arguments = "-ssh -x -C root@" + IP + " -pw alpine -m " + command;

                p.StartInfo.FileName = path;
                p.Start();
            }
            catch { }
        }

        public void OpenPuttyCommand(string IP, string command, ref Process p)
        {
            try
            {
                string path = @"putty.exe";

                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.ErrorDialog = false;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.RedirectStandardError = false;
                p.EnableRaisingEvents = true;

                p.StartInfo.Arguments = "-ssh -x -C root@" + IP + " -pw alpine " + command;

                p.StartInfo.FileName = path;
                p.Start();
            }
            catch { }
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            Config cf = Utility.LoadConfig();
            if (cf == null)
                cf = new Config();
            cf.Sleep = int.Parse(txtSleep.Text);
            cf.Username = txtUsername.Text;
            cf.Password = txtPassword.Text;
            cf.DefaultIP = txtDefaultIP.Text;
            cf.RoundClickAd = int.Parse(txtRoundClickAd.Text.ToString());
            cf.AdPoint = new Point(int.Parse(txtPointX.Text.ToString()), int.Parse(txtPointY.Text.ToString()));
            cf.RoundResetIDFV = int.Parse(txtRoundResetIDFV.Text);
            cf.WaitKillPutty = (int)WaitKillPutty.Value;
            cf.VNCName = txtVNCName.Text;
            Utility.SaveConfig(cf);
        }
        public void LoadConfigtoForm()
        {
            Config cf = Utility.LoadConfig();
            txtRoundClickAd.Text = cf.RoundClickAd.ToString();
            txtSleep.Text = cf.Sleep.ToString();
            txtPointY.Text = cf.AdPoint.Y.ToString();
            txtPointX.Text = cf.AdPoint.X.ToString();
            txtPassword.Text = cf.Password;
            txtUsername.Text = cf.Username;

            txtDefaultIP.Text = cf.DefaultIP;
            WaitKillPutty.Value = cf.WaitKillPutty;

            txtRoundClickAd.Text = cf.RoundClickAd.ToString();
            txtRoundResetIDFV.Text = cf.RoundResetIDFV.ToString();
            txtVNCName.Text = cf.VNCName;
        }



        private void clbApplist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btSaveListIp_Click(object sender, EventArgs e)
        {

            BindingList<Iphone> listIP = (BindingList<Iphone>)gridlist.DataSource;


            Utility.SaveListIP(listIP);
            Utility.ListIPtoFiles(listIP);

        }

        private void btSaveAppFromGrid_Click(object sender, EventArgs e)
        {
            BindingList<App> listIP = (BindingList<App>)gridApps.DataSource;


            Utility.SaveListAppsGrid(listIP);
        }

        private void btGenerateCommand_Click(object sender, EventArgs e)
        {
            List<App> iphones = Utility.LoadApps();
            foreach (App item in iphones)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + "\\commands\\" + item.BundleID + ".txt");
                //sw.WriteLine("sleep 10");
                sw.WriteLine("killall -c \"" + item.AppName + "\"");
                sw.WriteLine("sleep 5");
                sw.WriteLine("activator send " + item.BundleID);
                sw.WriteLine("sleep 30");
                sw.WriteLine("activator send libactivator.system.homebutton");
                sw.Close();


                System.IO.StreamWriter sw1 = new System.IO.StreamWriter(Application.StartupPath + "\\commands\\" + item.BundleID + "-reset.txt");
                sw1.WriteLine("sleep 3");

                sw1.WriteLine("rm /var/db/lsd/com.apple.lsdidentifiers.plist");
                sw1.WriteLine("sleep 3");

                sw1.WriteLine("killall -c '" + item.AppName + "'");
                sw1.WriteLine("sleep 5");
                sw1.WriteLine("activator send " + item.BundleID);
                sw1.WriteLine("sleep 30");
                sw1.WriteLine("activator send libactivator.system.homebutton");
                sw1.Close();
            }
        }



        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public void starWithWindows()
        {


            if (rkApp.GetValue("AutoGAME2017") == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                cbStartWindows.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                cbStartWindows.Checked = true;
            }
        }
        private void cbStartWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStartWindows.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("AutoGAME2017", Application.ExecutablePath);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("AutoGAME2017", false);
            }
        }

        private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoStart.Checked)
            {
                Config config = Utility.LoadConfig();
                config.AutoStart = true;
                Utility.SaveConfig(config);


            }
            else
            {
                Config config = Utility.LoadConfig();
                config.AutoStart = false;
                Utility.SaveConfig(config);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Random rnd = new Random();
            //int a = rnd.Next(0, 2);
            //MessageBox.Show(a.ToString());


            Process[] p = Process.GetProcessesByName("putty");
            try
            {
                if (p != null)
                {
                    foreach (Process item in p)
                    {
                        item.Kill();

                    }
                }
            }
            catch
            {
            }
            Environment.Exit(1);
        }

        private void btClearComand_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Application.StartupPath + "\\commands\\");
            var files = dir.GetFiles();
            if (files != null)
                foreach (var item in files)
                {
                    item.Delete();
                }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            RunRESET_PHONE();
        }

        public void RunRESET_PHONE()
        {
            Apps = Utility.LoadApps();
            List<Iphone> iphones = GetListIPFromGrid();



            foreach (var item in iphones)
            {
                string[] appstr = item.Apps.Split(',');

                string[] appBundleID = new string[appstr.Length];
                for (int i = 0; i < appstr.Length; i++)
                {
                    int AppID = int.Parse(appstr[i]);
                    App app = new App();
                    app = (App)Apps.Where(a => a.ID == AppID).FirstOrDefault();
                    appBundleID[i] = app.BundleID;
                }

                Thread thread = new Thread(() => ONLYRESET(item, appBundleID));
                thread.Start();


            }


        }

        public void ONLYRESET(Iphone iphone, string[] apps)
        {

            Random rnd = new Random();
            string commandFile = "reset-phone";// "commands\\" + apps[rnd.Next(0, apps.Length)];
            iphone.OpenNumber += 1;
            //if (iphone.OpenNumber % Config.iConfig.RoundResetIDFV == 0)
            //{
            //    //reset idfa,idfv
            //    commandFile = commandFile + "-reset";
            //}
            //else if (iphone.OpenNumber % Config.iConfig.RoundClickAd == 0)
            //{
            //    commandFile = "click-ad";
            //}
            Process p = new Process();
            OpenPutty(Config.iConfig.DefaultIP + iphone.IP, commandFile + ".txt", ref p);
            System.Threading.Thread.Sleep(Config.iConfig.WaitKillPutty);
            //Process[] p = Process.GetProcessesByName("putty");
            try
            {
                p.Kill();

            }
            catch
            {
            }
            ONLYRESET(iphone, apps);
        }

        private void ListIPCopy_Click(object sender, EventArgs e)
        {
            BindingList<Iphone> listVNC = new BindingList<Iphone>();
            string[] listStr = txtListIP.Text.Split('\n');

            foreach (string item in listStr)
            {
                string str = item.Replace("\r", "");//System.Environment.NewLine
                Iphone v = new Iphone();
                v.IP = str;
                v.Select = true;
                listVNC.Add(v);
            }
            Utility.SaveListIP(listVNC);
            LoadFirst();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }




        public void OpenPSCP(string IP, string fileName, string Filepath, ref Process p)
        {
            try
            {
                string path = @"pscp.exe";

                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.ErrorDialog = false;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.RedirectStandardError = false;
                p.EnableRaisingEvents = true;

                p.StartInfo.Arguments = "-pw alpine " + Filepath + " root@" + IP + ":/User/Library/runbatch/scripts/" + fileName;

                p.StartInfo.FileName = path;
                p.Start();
            }
            catch { }
        }

       

        private void btGenBashScript_Click(object sender, EventArgs e)
        {
            var scriptPath = Application.StartupPath + "\\bashscript";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(scriptPath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            List<Iphone> iphones = GetListIPFromGrid();
            string template = System.IO.File.ReadAllText(scriptPath + "\\template.txt");
            foreach (Iphone item in iphones)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(scriptPath + "\\" + item.IP + ".sh");
                //sw.WriteLine("sleep 10");
                int numapp = 1;
                //string app1 = "", app2 = "", app3 = "";
                //string appname1 = "", appname2 = "", appname3 = "";



                string[] appstr = item.Apps.Split(',');

                // string[] appBundleID = new string[appstr.Length];
                List<App> apps = new List<App>();
                for (int i = 0; i < appstr.Length; i++)
                {
                    int AppID = int.Parse(appstr[i]);
                    App app = new App();
                    app = (App)Apps.Where(a => a.ID == AppID).FirstOrDefault();
                    apps.Add(app);
                }



                numapp = apps.Count;
               // app1 = apps[0].BundleID;
               




                string temp = template;
                temp = temp.Replace("[[[numapp]]]", numapp.ToString());
                temp = temp.Replace("[[[numreset]]]", Config.iConfig.RoundResetIDFV.ToString());
                temp = temp.Replace("[[[numclick]]]",Config.iConfig.RoundClickAd.ToString());
                if (cbClearCaches.Checked)
                {
                    temp = temp.Replace("[[[caches]]]", "rm $(find //var/mobile/Applications -name 'Caches') -rf");
                }
                else
                {
                    temp = temp.Replace("[[[caches]]]", "");
                }

                if (apps.Count > 0)
                {
                    temp = temp.Replace("[[[app1]]]", apps[0].BundleID);
                    temp = temp.Replace("[[[appname1]]]", "'"+ apps[0].AppName + "'");
                }
                if (apps.Count > 1)
                {
                    temp = temp.Replace("[[[app2]]]", apps[1].BundleID);
                    temp = temp.Replace("[[[appname2]]]", "'"+ apps[1].AppName + "'");
                }
                if (apps.Count > 3)
                {
                    temp = temp.Replace("[[[app3]]]", apps[2].BundleID);
                    temp = temp.Replace("[[[appname3]]]", "'"+ apps[2].AppName + "'");
                }


                sw.WriteLine(temp);
                sw.Close();



                System.IO.StreamWriter sw1 = new System.IO.StreamWriter(scriptPath + "\\" + item.IP+ "-permission" + ".txt");
                sw1.WriteLine("chmod 777 /User/Library/runbatch/scripts/" + item.IP + ".sh");
                sw1.Close();

                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(scriptPath + "\\" + item.IP + "-run" + ".txt");
                sw2.WriteLine("bash /User/Library/runbatch/scripts/" + item.IP + ".sh");
                sw2.Close();

            }
        }

        private void btCopyScript_Click(object sender, EventArgs e)
        {
            List<Iphone> iphones = GetListIPFromGrid();
            // var scriptPath = Application.StartupPath + "\\bashscript";

            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();
                OpenPSCP(Config.iConfig.DefaultIP + item.IP, item.IP+ ".sh", Application.StartupPath + "\\bashscript\\" + item.IP + ".sh", ref p);


            }
        );


          
        }

        private void btScriptPermission_Click(object sender, EventArgs e)
        {
            List<Iphone> iphones = GetListIPFromGrid();
            // var scriptPath = Application.StartupPath + "\\bashscript";

            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();
               // OpenPSCP("192.168.1.111", item.IP + ".sh", Application.StartupPath + "\\bashscript\\" + item.IP + ".sh", ref p);

            //OpenPuttyCommand(Config.iConfig.DefaultIP + item.IP, "; sleep 10; chmod 777 /User/Library/runbatch/scripts/"+ item.IP + ".sh", ref p);

                OpenPutty(Config.iConfig.DefaultIP + item.IP,"bashscript\\"+ item.IP + "-permission.txt", ref p);
                

            });
        }

        private void btRespringAll_Click(object sender, EventArgs e)
        {
            List<Iphone> iphones = GetListIPFromGrid();
            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();
               
                OpenPutty(Config.iConfig.DefaultIP + item.IP, "respring.txt", ref p);


            });
        }

        private void btHomeAll_Click(object sender, EventArgs e)
        {
            List<Iphone> iphones = GetListIPFromGrid();
            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();

                OpenPutty(Config.iConfig.DefaultIP + item.IP, "homebutton.txt", ref p);


            });
        }

        private void btReboot_Click(object sender, EventArgs e)
        {
            List<Iphone> iphones = GetListIPFromGrid();
            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();

                OpenPutty(Config.iConfig.DefaultIP + item.IP, "reboot.txt", ref p);


            });
        }

        private void gridlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != 0)
            //{
            //    DataGridView dgv = sender as DataGridView;
            //    var abcd = dgv.Rows[0].Cells[e.ColumnIndex].Value.ToString();
            //}
        }

        private void gridlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingList<Iphone> listVNC = (BindingList<Iphone>)gridlist.DataSource;
            // DataGridView dgv = sender as DataGridView;
            //var abcd = dgv.Rows[0].Cells[0].Value.ToString();
            string fullIP = Config.iConfig.DefaultIP + listVNC[e.RowIndex].IP;
            if (e.ColumnIndex == 0)
            {

                string tempIP = Application.StartupPath + "\\vnc\\" + fullIP + ".vnc";


                Process.Start(tempIP);
            }
            else if (e.ColumnIndex == 1)
            {

                string tempIP = Config.iConfig.DefaultIP + listVNC[e.RowIndex].IP;
                Process p = new Process();



                string path = @"putty.exe";



                p.StartInfo.Arguments = "-ssh -x -C root@" + tempIP + " -pw alpine";

                p.StartInfo.FileName = path;
                p.Start();

            }
            else if (e.ColumnIndex == 2)
            {
                Process p = new Process();
                OpenPSCP(fullIP, listVNC[e.RowIndex].IP+ ".sh", Application.StartupPath + "\\bashscript\\" + listVNC[e.RowIndex].IP + ".sh", ref p);

            }
            else if (e.ColumnIndex == 3)
            {
                Process p = new Process();
                OpenPutty(fullIP,  Application.StartupPath + "\\reboot.txt", ref p);

            }
            else if (e.ColumnIndex == 4)
            {
                Process p = new Process();
                OpenPutty(fullIP, Application.StartupPath + "\\respring.txt", ref p);

            }
            else if (e.ColumnIndex == 5)
            {
                Process p = new Process();
                OpenPutty(fullIP,  Application.StartupPath + "\\reset-phone.txt", ref p);

            }

            else if (e.ColumnIndex == 6)
            {
                Process p = new Process();
                OpenPutty(fullIP, "bashscript\\" + listVNC[e.RowIndex].IP + "-run.txt", ref p);

            }



        }

        private void btRunScript_Click(object sender, EventArgs e)
        {
            List<Iphone> iphones = GetListIPFromGrid();
            // var scriptPath = Application.StartupPath + "\\bashscript";

            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();
                OpenPutty(Config.iConfig.DefaultIP + item.IP, "bashscript\\" + item.IP + "-run.txt", ref p);


            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Iphone> iphones = GetListIPFromGrid();
            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();

                OpenPutty(Config.iConfig.DefaultIP + item.IP, "reboot.txt", ref p);


            });

            Thread.Sleep(180000);
            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();

                OpenPutty(Config.iConfig.DefaultIP + item.IP, "homebutton.txt", ref p);


            });
            Thread.Sleep(15000);
            Parallel.ForEach(iphones, item =>
            {

                Process p = new Process();
                OpenPutty(Config.iConfig.DefaultIP + item.IP, "bashscript\\" + item.IP + "-run.txt", ref p);


            });
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            BindingList<Iphone> listVNC = (BindingList<Iphone>)gridlist.DataSource;
            if (cbAll.Checked)
            {
                foreach (var item in listVNC)
                {
                    item.Select = true;
                }
            }
            else
            {
                foreach (var item in listVNC)
                {
                    item.Select = false;
                }
            }
            gridlist.DataSource = listVNC;
           
            
        }

        private void btKillPutty_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("putty");
            try
            {
                if (p != null)
                {
                    foreach (Process item in p)
                    {
                        item.Kill();

                    }
                }
            }
            catch
            {
            }



            Process[] p2 = Process.GetProcessesByName(Config.iConfig.VNCName);
            try
            {
                if (p2 != null)
                {
                    foreach (Process item in p2)
                    {
                        item.Kill();

                    }
                }
            }
            catch
            {
            }
        }

        private void btKillCocCoc_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("browser");
            try
            {
                if (p != null)
                {
                    foreach (Process item in p)
                    {
                        item.Kill();

                    }
                }
            }
            catch
            {
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("Chrome");
            try
            {
                if (p != null)
                {
                    foreach (Process item in p)
                    {
                        item.Kill();

                    }
                }
            }
            catch
            {
            }
        }

        private void btkillFirefox_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("Firefox");
            try
            {
                if (p != null)
                {
                    foreach (Process item in p)
                    {
                        item.Kill();

                    }
                }
            }
            catch
            {
            }
        }
    }
}
