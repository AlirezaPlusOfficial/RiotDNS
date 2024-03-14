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


            if (DnsName == "Radar Game")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.radarAdr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            } 
            else if (DnsName == "Electro")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.electroAdr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }
            else if (DnsName == "Shecan")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.shecanAdr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }
            else if (DnsName == "Begzar")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.begzarAdr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }
            else if (DnsName == "Anti 403")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.anti403Adr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }
            else if (DnsName == "OpenDNS")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.opendnsAdr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }
            else if (DnsName == "CloudFlare")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.cloudflareAdr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }
            else if (DnsName == "Google")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.googleAdr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }
            else if (DnsName == "Quad 9")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.quad9Adr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }
            else if (DnsName == "KeepSolid")
            {
                PingReply reply = await pingSender.SendPingAsync(settings.keepsolidAdr[0]);
                CurrentPing += (int)reply.RoundtripTime;
            }



            if (CurrentPing == 0)
            {
                return "[?]";
            }
            else
            {
                return $"[{CurrentPing}ms]";
            }
            
        }

    }
}
