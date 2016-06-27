using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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
        Process amixerMediaProcess = new Process();
        public List<App> Apps = new List<App>();
        private void btStart_Click(object sender, EventArgs e)
        {
            RunAutoGame();

        }
        public void RunAutoGame()
        {
            Apps = Utility.LoadApps();
            List<Iphone> iphones = Utility.LoadIPList();
            if (iphones != null)
            {
                Parallel.ForEach(iphones, iphone =>
                { 
                    string[] appstr = iphone.Apps.Split(',');

                    string[] appBundleID = new string[appstr.Length];
                    for (int i = 0; i < appstr.Length; i++)
                    {
                        int AppID = int.Parse(appstr[i]);
                        App app = new App();
                        app = (App)Apps.Where(a => a.ID == AppID).FirstOrDefault();
                        appBundleID[i] = app.BundleID;
                    }

                    openApp(iphone, appBundleID);



                }
            );
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
            else if (iphone.OpenNumber == Config.iConfig.RoundClickAd)
            {
                commandFile = "click-ad";
            }
            OpenPutty(Config.iConfig.DefaultIP + iphone.IP,  commandFile + ".txt");
            System.Threading.Thread.Sleep(30000);
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

        public void OpenPutty(string IP, string command)
        {

            string path = @"putty.exe";

            amixerMediaProcess.StartInfo.CreateNoWindow = false;
            amixerMediaProcess.StartInfo.UseShellExecute = false;
            amixerMediaProcess.StartInfo.ErrorDialog = false;
            amixerMediaProcess.StartInfo.RedirectStandardOutput = false;
            amixerMediaProcess.StartInfo.RedirectStandardInput = false;
            amixerMediaProcess.StartInfo.RedirectStandardError = false;
            amixerMediaProcess.EnableRaisingEvents = true;

            amixerMediaProcess.StartInfo.Arguments = "-ssh -x -C root@" + IP + " -pw alpine -m " + command;

            amixerMediaProcess.StartInfo.FileName = path;
            amixerMediaProcess.Start();
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
                sw.WriteLine("killall -c '" + item.AppName + "'");
                sw.WriteLine("sleep 5");
                sw.WriteLine("activator send phuongnguyennew.Bird-Jump");
                sw.WriteLine("sleep 10");
                sw.Close();


                System.IO.StreamWriter sw1 = new System.IO.StreamWriter(Application.StartupPath + "\\commands\\" + item.BundleID + "-reset.txt");
                sw1.WriteLine("sleep 3");

                sw1.WriteLine("rm /var/db/lsd/com.apple.lsdidentifiers.plist");
                sw1.WriteLine("sleep 3");
                
                sw1.WriteLine("killall -c '" + item.AppName + "'");
                sw1.WriteLine("sleep 5");
                sw1.WriteLine("activator send phuongnguyennew.Bird-Jump");
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


    }
}
