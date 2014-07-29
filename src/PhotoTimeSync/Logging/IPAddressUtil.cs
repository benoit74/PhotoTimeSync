using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    public class IPAddressUtil
    {
        public static string GetInterNetworkIPAddress(bool useIPV6IfAvailable)
        {
            IPHostEntry host;
            string localIP = "?";
            string localIPV6 = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    localIPV6 = ip.ToString();
                }
            }
            string bestLocalIP = (!useIPV6IfAvailable || localIPV6 == "?") ? localIP : localIPV6;
            return bestLocalIP;

        }
    }
}
