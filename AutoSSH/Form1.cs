using Microsoft.Win32;
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
            Apps = Utility.LoadApps();
            List<Iphone> iphones = Utility.LoadIPList();
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

      

        
        public void openApp(Iphone iphone, string[] apps)
        {
             
            Random rnd = new Random();
            string commandFile ="commands\\" + apps[rnd.Next(0, apps.Length)];
            iphone.OpenNumber += 1;
            if (iphone.OpenNumber%Config.iConfig.RoundResetIDFV == 0)
            { 
                //reset idfa,idfv
                commandFile=commandFile+"-reset";
            }
            else if (iphone.OpenNumber%Config.iConfig.RoundClickAd==0)
            {
                commandFile = "click-ad";
            }
            Process p = new Process();
            OpenPutty(Config.iConfig.DefaultIP + iphone.IP,  commandFile + ".txt",ref p);
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

            if (Config.iConfig.AutoStart)
            {
                RunAutoGame();
            }
        }

        public void LoadListAppsToForm()
        {
            gridApps.DataSource = Utility.LoadListAppstoGrid();
        }

        public void OpenPutty(string IP, string command,ref Process p)
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
            cf.RoundResetIDFV=int.Parse(txtRoundResetIDFV.Text);
            cf.WaitKillPutty = (int)WaitKillPutty.Value;
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
        }



        private void clbApplist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btSaveListIp_Click(object sender, EventArgs e)
        {

            BindingList<Iphone> listIP = (BindingList<Iphone>)gridlist.DataSource;


            Utility.SaveListIP(listIP);


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
                sw.WriteLine("sleep 10");
                sw.Close();


                System.IO.StreamWriter sw1 = new System.IO.StreamWriter(Application.StartupPath + "\\commands\\" + item.BundleID + "-reset.txt");
                sw1.WriteLine("sleep 3");

                sw1.WriteLine("rm /var/db/lsd/com.apple.lsdidentifiers.plist");
                sw1.WriteLine("sleep 3");
                
                sw1.WriteLine("killall -c '" + item.AppName + "'");
                sw1.WriteLine("sleep 5");
                sw1.WriteLine("activator send "+ item.BundleID);
                sw1.WriteLine("sleep 10");
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
            var files=dir.GetFiles();
            foreach (var item in files)
            {
                item.Delete();
            }
        }
    }
}
