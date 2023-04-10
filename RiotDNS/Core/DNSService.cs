using System.Management;

namespace RiotDNS
{

    public class DNSService 
    {
        
        Controller controller = new Controller();
        Settings settings = new Settings();

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
                            objdns["DNSServerSearchOrder"] = settings.radarAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Electro")
                        {
                            objdns["DNSServerSearchOrder"] = settings.electroAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Shecan")
                        {
                            objdns["DNSServerSearchOrder"] = settings.shecanAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Begzar")
                        {
                            objdns["DNSServerSearchOrder"] = settings.begzarAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Anti 403")
                        {
                            objdns["DNSServerSearchOrder"] = settings.anti403Adr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "OpenDNS")
                        {
                            objdns["DNSServerSearchOrder"] = settings.opendnsAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Cloudflare")
                        {
                            objdns["DNSServerSearchOrder"] = settings.cloudflareAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Google")
                        {
                            objdns["DNSServerSearchOrder"] = settings.googleAdr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                        else if (DnsName == "Quad 9")
                        {
                            objdns["DNSServerSearchOrder"] = settings.quad9Adr;
                            mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }

                    }
                }
            }
            controller.LogWrite("CONNECTED TO " + DnsName);
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
                        controller.LogWrite("SYSTEM DNS SERVERS CLEARED");

                    }
                }

            }
        }
    }

}
