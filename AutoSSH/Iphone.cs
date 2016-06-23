using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
namespace AutoSSH
{
    public class App
    {
        public string BundleID { get; set; }
        public string Name { get; set; }

    }

    public class Iphone
    {
        public string IP { get; set; }
        public List<App> Apps { get; set; } 
       // public string Username { get; set}
       // public string Password { get; set; }
        

    }
     
}
