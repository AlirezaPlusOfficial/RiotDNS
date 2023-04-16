using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Reflection;

namespace RiotDNS
{
    public class Settings
    {
        public bool devMode = false;
        public readonly string[] dnsServers = { "Radar Game", "Electro", "Shecan", "Begzar", "Anti 403", "OpenDNS", "CloudFlare", "Google", "Quad9" };
        public readonly string[] radarAdr = { "10.202.10.10", "10.202.10.11" };
        public readonly string[] electroAdr = { "78.157.42.100", "78.157.42.101" };
        public readonly string[] shecanAdr = { "178.22.122.100", "185.51.200.2" };
        public readonly string[] begzarAdr = { "185.55.226.26", "185.55.225.25" };
        public readonly string[] anti403Adr = { "10.202.10.202", "10.202.10.102" };
        public readonly string[] opendnsAdr = { "208.67.222.222", "208.67.220.220" };
        public readonly string[] cloudflareAdr = { "1.1.1.1", "1.0.0.1" };
        public readonly string[] googleAdr = { "8.8.8.8", "8.8.4.4" };
        public readonly string[] quad9Adr = { "9.9.9.9", "149.112.112.112" };
        private string appVersion;

        public bool CheckAdmin()
        {
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public string GetRDVersion()
        {
            appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return appVersion;
        }
        
    }
}
