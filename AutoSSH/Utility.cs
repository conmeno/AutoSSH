using AutoSSH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
namespace AutoSSH
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MousePoint
    {
        public int X;
        public int Y;

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
    class Utility
    {

        #region VNC

        private const int WM_CLOSE = 16;
        private const int BN_CLICKED = 245;

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
        [DllImport("user32.dll")]
        public static extern int GetDlgCtrlID(IntPtr hwnd);
        //mouse
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }



        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoin);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;

        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;

        //
        System.Data.Odbc.OdbcDataAdapter obj_oledb_da;

      

        #endregion


        public static string Serialize(object oObject, bool Indent = false)
        {
            System.Xml.Serialization.XmlSerializer oXmlSerializer = null;
            System.Text.StringBuilder oStringBuilder = null;
            System.Xml.XmlWriter oXmlWriter = null;
            string sXML = null;
            System.Xml.XmlWriterSettings oXmlWriterSettings = null;
            System.Xml.Serialization.XmlSerializerNamespaces oXmlSerializerNamespaces = null;

            // -----------------------------------------------------------------------------------------------------------------------
            // Lage XML
            // -----------------------------------------------------------------------------------------------------------------------
            oStringBuilder = new System.Text.StringBuilder();
            oXmlSerializer = new System.Xml.Serialization.XmlSerializer(oObject.GetType());
            oXmlWriterSettings = new System.Xml.XmlWriterSettings();
            oXmlWriterSettings.OmitXmlDeclaration = true;
            oXmlWriterSettings.Indent = Indent;
            oXmlWriter = System.Xml.XmlWriter.Create(new System.IO.StringWriter(oStringBuilder), oXmlWriterSettings);
            oXmlSerializerNamespaces = new System.Xml.Serialization.XmlSerializerNamespaces();
            oXmlSerializerNamespaces.Add(string.Empty, string.Empty);
            oXmlSerializer.Serialize(oXmlWriter, oObject, oXmlSerializerNamespaces);
            oXmlWriter.Close();
            sXML = oStringBuilder.ToString();

            return sXML;
        }

        public static object DeSerialize(string sXML, Type ObjectType)
        {
            System.IO.StringReader oStringReader = null;
            System.Xml.Serialization.XmlSerializer oXmlSerializer = null;
            object oObject = null;

            // -----------------------------------------------------------------------------------------------------------------------
            // Hvis mangler info, lage tom
            // -----------------------------------------------------------------------------------------------------------------------
            if (sXML == string.Empty)
            {
                Type[] types = new Type[-1 + 1];
                System.Reflection.ConstructorInfo info = ObjectType.GetConstructor(types);
                object targetObject = info.Invoke(null);
                if (targetObject == null)
                    return null;
                return targetObject;
            }

            // -----------------------------------------------------------------------------------------------------------------------
            // Gjøre om fra XML til objekt
            // -----------------------------------------------------------------------------------------------------------------------
            oStringReader = new System.IO.StringReader(sXML);
            oXmlSerializer = new System.Xml.Serialization.XmlSerializer(ObjectType);
            oObject = oXmlSerializer.Deserialize(oStringReader);

            return oObject;
        }
     

        public static Config LoadConfig(bool vncPoint = true)
        {
            string ConfigPath = Application.StartupPath + "\\config.txt";
            Config Config = new Config();
            try
            {
                Config = (Config)DeSerialize(System.IO.File.ReadAllText(ConfigPath), typeof(Config));

                if (vncPoint)
                {
                    Config.AppPoint = new Point(Config.VNCPoint.X + Config.AppPoint.X, Config.VNCPoint.Y + Config.AppPoint.Y); 

                    Config.AdPoint = new Point(Config.VNCPoint.X + Config.AdPoint.X, Config.VNCPoint.Y + Config.AdPoint.Y);

                    Config.ClosePoint = new Point(Config.VNCPoint.X + Config.ClosePoint.X, Config.VNCPoint.Y + Config.ClosePoint.Y); 

                    Config.AdvertisingPoint = new Point(Config.VNCPoint.X + Config.AdvertisingPoint.X, Config.VNCPoint.Y + Config.AdvertisingPoint.Y);

                    Config.AdvertisingPoint1 = new Point(Config.VNCPoint.X + Config.AdvertisingPoint1.X, Config.VNCPoint.Y + Config.AdvertisingPoint1.Y);

                    Config.AdvertisingPoint2 = new Point(Config.VNCPoint.X + Config.AdvertisingPoint2.X, Config.VNCPoint.Y + Config.AdvertisingPoint2.Y);



                }
            }
            catch
            {
                Config = null;
            }

            Config.iConfig = Config;
            return Config;
        }


        public static void SaveConfig(Config Config)
        {
            string ConfigPath = Application.StartupPath + "\\config.txt";

            string XML = Serialize(Config, true);
            System.IO.StreamWriter sr = new StreamWriter(ConfigPath);
            sr.WriteLine(XML);
            sr.Close();

        }
        public static List<App> LoadApps()
        {
            string ConfigPath = Application.StartupPath + "\\Apps.txt";
            List<App> apps = new List<App>();
            try
            {
                apps = (List<App>)DeSerialize(System.IO.File.ReadAllText(ConfigPath), typeof(List<App>));

            }
            catch
            {
                apps = new List<App>();
            }

            
            return apps;
        }
        public static void SaveApps(List<App> app)
        {
            string ConfigPath = Application.StartupPath + "\\Apps.txt";

            string XML = Serialize(app, true);
            System.IO.StreamWriter sr = new StreamWriter(ConfigPath);
            sr.WriteLine(XML);
            sr.Close();

        }

        public static BindingList<Iphone> LoadIPListBind()
        {
            string VNCListPath = Application.StartupPath + "\\ListIP.txt";
            BindingList<Iphone> listVNC = new BindingList<Iphone>();
            try
            {
                listVNC = (BindingList<Iphone>)DeSerialize(System.IO.File.ReadAllText(VNCListPath), typeof(BindingList<Iphone>));
            }
            catch
            {

            }

            return listVNC;
        }


        public static List<Iphone> LoadIPList()
        {
            string VNCListPath = Application.StartupPath + "\\ListIP.txt";
            List<Iphone> listVNC = new List<Iphone>();
            try
            {
                listVNC = (List<Iphone>)DeSerialize(System.IO.File.ReadAllText(VNCListPath), typeof(List<Iphone>));
            }
            catch
            {

            }

            return listVNC;
        }



        public static void SaveListIP(BindingList<Iphone> listIP)
        {
            string VNCListPath = Application.StartupPath + "\\ListIP.txt";
            //if (listVNC.Count == 0)
            //    listVNC.Add(new VNC());
            string XML = Serialize(listIP, true);
            System.IO.StreamWriter sr = new StreamWriter(VNCListPath);
            sr.WriteLine(XML);
            sr.Close();
        }




        public static BindingList<App> LoadListAppstoGrid()
        {
            string VNCListPath = Application.StartupPath + "\\Apps.txt";
            BindingList<App> listVNC = new BindingList<App>();
            try
            {
                listVNC = (BindingList<App>)DeSerialize(System.IO.File.ReadAllText(VNCListPath), typeof(BindingList<App>));
            }
            catch
            {

            }

            return listVNC;
        }
        public static void SaveListAppsGrid(BindingList<App> listIP)
        {
            string VNCListPath = Application.StartupPath + "\\Apps.txt";
            //if (listVNC.Count == 0)
            //    listVNC.Add(new VNC());
            string XML = Serialize(listIP, true);
            System.IO.StreamWriter sr = new StreamWriter(VNCListPath);
            sr.WriteLine(XML);
            sr.Close();
        }


        public static void ListIPtoFiles(BindingList<Iphone> VNCList)
        {
            string VNCPath = Application.StartupPath + "\\vnc";
            DirectoryInfo VNC = new DirectoryInfo(VNCPath);
            if (!Directory.Exists(VNCPath))
                Directory.CreateDirectory(VNCPath);
            string VNCConfigTextFile = Application.StartupPath + "vnc\\VNCConfigFile.txt";
            string VNCConfigText = "";
            if (File.Exists(VNCConfigTextFile))
            {
                VNCConfigText = File.ReadAllText(VNCConfigTextFile);
            }
            foreach (var item in VNCList)
            {
                if (item.IP != null && item.IP != string.Empty)
                {
                    string fileName = VNCPath + "\\" + Config.iConfig.DefaultIP + item.IP + ".vnc";
                    StreamWriter sw = new StreamWriter(fileName);
                    sw.WriteLine("[Connection]");
                    sw.WriteLine("Host=" + Config.iConfig.DefaultIP + item.IP);
                    sw.WriteLine("Password=b4d90014103bde54");
                    sw.WriteLine(VNCConfigText);
                    sw.Close();
                }

            }

        }



    }
}
