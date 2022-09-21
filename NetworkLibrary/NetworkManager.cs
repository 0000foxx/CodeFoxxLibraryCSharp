using System;
using System.Net;
using System.Net.Sockets;
using LogLibrary;

namespace CodeFoxxLibrary.NetworkLibrary
{
    public class NetworkManager
    {
        public enum NetType
        {
            INTERNET, INTRANET
        }

        public static NetType CheckIntranetOrInternet(string targetIP)
        {
            string[] targetIPSections = targetIP.Split('.');

            /// IP地址中，有三段地址專門用於私網的規劃，不能被用於網際網路上的連線如下
            /// Class A：10.0.0.0-10.255.255.255
            if (targetIPSections[0] == "10")
            {
                return NetType.INTRANET;
            }

            /// Class B：172.16.0.0-172.31.255.255
            if (targetIPSections[0] == "172")
            {
                int targetIPSecondSection = Convert.ToInt16(targetIPSections[1]);
                if (targetIPSecondSection >= 16 && targetIPSecondSection <= 31)
                {
                    return NetType.INTRANET;
                }
            }

            /// Class C：192.168.0.0-192.168.255.255
            if (targetIPSections[0] == "192" && targetIPSections[1] == "168")
            {
                return NetType.INTRANET;
            }

            return NetType.INTERNET;
        }

        public static string GetLocalIP()
        {
            string localIP = string.Empty;
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIP = endPoint.Address.ToString();
                }
            }
            catch (Exception e)
            {
                LogManager.Debug(e.ToString());
            }

            return localIP;
        }
    }
}

