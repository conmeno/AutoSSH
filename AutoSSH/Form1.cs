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
            List<Iphone> iphones = Utility.LoadIPList();
            if (iphones != null)
            {
                Parallel.ForEach(iphones, iphone =>
                {
                    OpenPutty(iphone.IP, "command.txt");

                }
            );
            }
            
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
            cf.AdPoint = new Point(int.Parse(txtPointX.ToString()), int.Parse(txtPointY.ToString()));
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

       
    }
}
