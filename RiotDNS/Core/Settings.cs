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
        public string[] dnsServers = { "Radar Game {?}", "Electro {?}", "Shecan {?}", "Begzar {?}", "Anti 403 {?}", "OpenDNS {?}", "CloudFlare {?}", "Google {?}", "Quad9 {?}" };

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
