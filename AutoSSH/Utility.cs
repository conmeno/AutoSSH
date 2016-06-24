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
    class Utility
    {
 
 
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
     

        public static Config LoadConfig()
        {
            string ConfigPath = Application.StartupPath + "\\config.txt";
            Config Config = new Config();
            try
            {
                Config = (Config)DeSerialize(System.IO.File.ReadAllText(ConfigPath), typeof(Config));
 
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


      



    }
}
