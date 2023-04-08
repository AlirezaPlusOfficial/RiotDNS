using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace RiotDNS
{

    public class DNSService 
    {
        private string[] radarAdr = { "10.202.10.10", "10.202.10.11" };
        private string[] electroAdr = { "78.157.42.100", "78.157.42.101" };
        private string[] shecanAdr = { "178.22.122.100", "185.51.200.2" };
        private string[] begzarAdr = { "185.55.226.26", "185.55.225.25" };
        private string[] anti403Adr = { "10.202.10.202", "10.202.10.102" };
        private string[] opendnsAdr = { "208.67.222.222", "208.67.220.220" };
        private string[] cloudflareAdr = { "1.1.1.1", "1.0.0.1" };
        private string[] googleAdr = { "8.8.8.8", "8.8.4.4" };
        private string[] quad9Adr = { "9.9.9.9", "149.112.112.112" };


        public string SetDNS(string DnsName)
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    ManagementBaseObject objdns = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    if (objdns != null)
                    {
                        if (DnsName == "Radar Game")
                        {
                            objdns["DNSServerSearchOrder"] = radarAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Electro")
                        {
                            objdns["DNSServerSearchOrder"] = electroAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Shecan")
                        {
                            objdns["DNSServerSearchOrder"] = shecanAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Begzar")
                        {
                            objdns["DNSServerSearchOrder"] = begzarAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Anti 403")
                        {
                            objdns["DNSServerSearchOrder"] = anti403Adr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "OpenDNS")
                        {
                            objdns["DNSServerSearchOrder"] = opendnsAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Cloudflare")
                        {
                            objdns["DNSServerSearchOrder"] = cloudflareAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Google")
                        {
                            objdns["DNSServerSearchOrder"] = googleAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Quad 9")
                        {
                            objdns["DNSServerSearchOrder"] = quad9Adr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }

                    }
                }
            }
            return "CONNECTED TO " + DnsName;
        }

        public void ClearDNS()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    ManagementBaseObject objdns = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    if (objdns != null)
                    {
                        mo.InvokeMethod("SetDNSServerSearchOrder", null);
                        

                    }
                }

            }
        }
    }

}
