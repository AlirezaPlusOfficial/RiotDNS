using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace RiotDNS
{
    public sealed class RiotDNSHttpsClient
    {
        private static RiotDNSHttpsClient _instance;
        private HttpClient client = new HttpClient();

        private RiotDNSHttpsClient() { }

        public static RiotDNSHttpsClient GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RiotDNSHttpsClient();
            }
            return _instance;
        }

        public HttpClient Client
        {
            get => client;
            set => client = value;
        }
    }
}
