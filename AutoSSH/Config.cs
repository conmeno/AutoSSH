using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
namespace AutoSSH
{
    public class Config
    {

      
     
        public Point AdPoint { get; set; } 
        public bool AutoStart { get; set; }//auto start application when open.

        public List<int> RespringTime { get; set; } // hours
 
        public string Username { get; set; }//user name and pass iphone
        public string Password { get; set; }
        public string DefaultIP { get; set; }//192.168.1.
        public int Sleep { get; set; }
        public int RoundResetIDFV { get; set; }
        public int RoundClickAd { get; set; }
        public int WaitKillPutty { get; set; }
        public string Note { get; set; }
        [XmlIgnore]
        public static Config iConfig { get; set; }
        public string VNCName { get; set; }



        //vnc config
        public Point VNCPoint { get; set; }
        public Point AppPoint { get; set; } 
        public Point ClosePoint { get; set; }  
        public decimal waitTimeVNC { get; set; }
        public decimal WaitEachRound { get; set; }  
        public Point AdvertisingPoint { get; set; }
        public Point AdvertisingPoint1 { get; set; }
        public Point AdvertisingPoint2 { get; set; }  
        public string VNCPasswordCode { get; set; }
    }
 
}
