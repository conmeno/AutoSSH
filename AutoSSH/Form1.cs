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
            List<Iphone> iphones = new List<Iphone>();
            iphones.Add(new Iphone { IP = "192.168.1.110" });

            iphones.Add(new Iphone { IP = "192.168.1.74" });
            Parallel.ForEach(iphones, iphone =>
            {
                OpenPutty(iphone.IP, "command.txt");

            }
            );
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFirst();

            
            //OpenPutty("192.168.1.110", "command2.txt");
        }


        public void LoadIphoneGrid()
        {
            gridlist.DataSource = Utility.LoadIPListBind();

        }
        public void LoadFirst()
        {
            Utility.LoadConfig();
            LoadListApp();
        }
        public void LoadListApp()
        {
            Apps = Utility.LoadApps();
            StringBuilder sb = new StringBuilder();
            foreach (App a in Apps)
            {
                sb.AppendLine(a.Name + "  " + a.BundleID);
            }
            txtListApp.Text = sb.ToString();

            LoadAppsCheckListbox();
        }

        public void LoadAppsCheckListbox()
        {
            StringBuilder sb = new StringBuilder();
            foreach (App a in Apps)
            {
                //sb.AppendLine(a.Name + "  " + a.BundleID);
                clbApp.Items.Add(a);
            }
            //clbApp.Text = sb.ToString();
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
            cf.Passwrod = txtPassword.Text;
            cf.DefaultIP = txtDefaultIP.Text;

            Utility.SaveConfig(cf);
        }

        

        private void btAddApp_Click(object sender, EventArgs e)
        {
            App app = new App();
            app.BundleID = txtBundleID.Text;
            app.Name = txtAppName.Text;
            Apps.Add(app);
            Utility.SaveApps(Apps);
        }

        private void clbApplist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btSaveListIp_Click(object sender, EventArgs e)
        {
           
            BindingList<Iphone> listIP = (BindingList<Iphone>)gridlist.DataSource;


            Utility.SaveListIP(listIP);


        }
    }
}
