using System;
using System.IO;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace RiotDNS
{
    public class Controller
    {
        Settings settings = new Settings(); 

        private string m_exePath = string.Empty;
        /*
        public Controller(string logMessage)
        {
            LogWrite(logMessage);
        }
        */
        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "RiotDNS_Log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  ->>");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }



        // PING SYSTEM REBUILT | STILL I HAVE SOME ISSUE WITH THIS BUT IT'S BETTER BY NOW


        public async Task<string> GetServerPing(string DnsName)
        {
            int CurrentPing = 0;
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;

            string targetAddress = null;

            try
            {
                // Use if-else instead of switch expression for compatibility with C# 7.3
                if (DnsName == "Radar Game") targetAddress = settings.radarAdr[0];
                else if (DnsName == "Electro") targetAddress = settings.electroAdr[0];
                else if (DnsName == "Shecan") targetAddress = settings.shecanAdr[0];
                else if (DnsName == "Begzar") targetAddress = settings.begzarAdr[0];
                else if (DnsName == "Anti 403") targetAddress = settings.anti403Adr[0];
                else if (DnsName == "OpenDNS") targetAddress = settings.opendnsAdr[0];
                else if (DnsName == "CloudFlare") targetAddress = settings.cloudflareAdr[0];
                else if (DnsName == "Google") targetAddress = settings.googleAdr[0];
                else if (DnsName == "Quad 9") targetAddress = settings.quad9Adr[0];
                else if (DnsName == "KeepSolid") targetAddress = settings.keepsolidAdr[0];

                // Proceed with ping if a valid address was found
                if (targetAddress != null)
                {
                    PingReply reply = await pingSender.SendPingAsync(targetAddress);
                    if (reply.Status == IPStatus.Success)
                    {
                        CurrentPing += (int)reply.RoundtripTime;
                    }
                    else
                    {
                        // Log if ping failed (e.g., unreachable host)
                        throw new Exception($"Ping to {DnsName} failed with status: {reply.Status}");
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid DNS name: {DnsName}");
                }

                // Return ping result or unknown if no valid reply received
                if (CurrentPing == 0)
                {
                    return "[?]";
                }
                else
                {
                    return $"[{CurrentPing}ms]";
                }
            }
            catch (PingException ex)
            {
                // Handle specific Ping exceptions (e.g., network issues)
                LogWrite($"Ping exception for {DnsName}: {ex.Message}");
                return "[Error]";
            }
            catch (Exception ex)
            {
                // Handle general exceptions (e.g., invalid DNS names)
                LogWrite($"Error in GetServerPing for {DnsName}: {ex.Message}");
                return "[Error]";
            }
        }




    }
}
