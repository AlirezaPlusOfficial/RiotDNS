using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Xml;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace RiotDNS
{
    
    public class AutoUpdater
    {
        Controller controller = new Controller();
        Settings Setting = new Settings();

        private string updateXmlUrl;
        private string applicationPath;
        private string applicationName;
        private Version currentVersion;
        private Version newVersion;
        private string updateUrl;
        private byte[] updateBytes;
        private string updateXml;
        public AutoUpdater()
        {
            updateXmlUrl = "https://raw.githubusercontent.com/AlirezaPlusOfficial/RiotDNS/master/Builds/data.xml";
            applicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            applicationName = "RiotDNS";
            currentVersion = new Version(Setting.GetRDVersion());
        }

        public void DoUpdate()
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(updateXmlUrl);
                while (reader.Read())
                {
                    if (reader.Name == "version")
                    {
                        newVersion = new Version(reader.ReadString());
                        if (newVersion > currentVersion)
                        {
                            //updateUrl = reader.ReadString();
                            //updateUrl = updateUrl.Replace("%applicationPath%", applicationPath);
                            WebClient webClient = new WebClient();

                            updateBytes = webClient.DownloadData(updateXmlUrl);
                            updateXml = Encoding.ASCII.GetString(updateBytes);

                            // Parse the manifest file to find the latest version number and other info
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(updateXml);
                            updateUrl = xmlDoc.SelectSingleNode("//url").InnerText;

                            controller.LogWrite("NEW VERSION DETECTED v" + newVersion);

                            Process.Start(applicationPath + "\\" + applicationName + ".Updater.exe");
                            System.Windows.Application.Current.Shutdown();

                        } 
                        else
                        {
                            if (File.Exists(applicationPath + "\\" + "RiotDNS" + "-TempUpdate.zip"))
                            {
                                File.Delete(applicationPath + "\\" + "RiotDNS" + "-TempUpdate.zip");
                            }
                            controller.LogWrite("CLIENT HAVE LATEST VERSION : v" + currentVersion);
                        }
                        if (!File.Exists(applicationPath + "\\" + "AlirezaPlus.dll"))
                        {
                            controller.LogWrite("NECESSARY COMPONENT NOT FOUND : " + "AlirezaPlus.dll" + " | EXECUTING UPDATER...");
                            Process.Start(applicationPath + "\\" + applicationName + ".Updater.exe");
                            System.Windows.Application.Current.Shutdown();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

    }

}