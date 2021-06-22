using System.Collections.Generic;

namespace NetworkLibrary
{
    public class NetworkManager
    {
        public enum NetType
        {
            INTERNET, INTRANET
        }

        public static NetType CheckIntranetOrInternet(string targetIP)
        {
            /// IP地址中，有三段地址專門用於私網的規劃，不能被用於網際網路上的連線如下
            /// Class A：10.0.0.0-10.255.255.255
            string intranetAClassFirstSection = "10.";
            List<string> intranetAClassHalfSection = new List<string>();
            for (int i = 0; i <= 255; ++i)
            {
                intranetAClassHalfSection.Add(intranetAClassFirstSection + i);
            }

            /// Class B：172.16.0.0-172.31.255.255
            string intranetBClassFirstSection = "172.";
            List<string> intranetBClassHalfSection = new List<string>();
            for (int i = 16; i <= 31; ++i)
            {
                intranetBClassHalfSection.Add(intranetBClassFirstSection + i);
            }

            /// Class C類：192.168.0.0-192.168.255.255
            string intranetCClass = "192.168";

            List<string> intranetIPs = new List<string>();
            intranetIPs.AddRange(intranetAClassHalfSection);
            intranetIPs.AddRange(intranetBClassHalfSection);
            intranetIPs.Add(intranetCClass);

            foreach (var intranetIP in intranetIPs)
            {
                if (targetIP.StartsWith(intranetIP))
                {
                    return NetType.INTRANET;
                }
            }

            return NetType.INTERNET;

            //for backup from survey
            //string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null ? Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : Request.UserHostAddress;
            //Debug.WriteLine($"ip = {ip}");
            //if (ip.IndexOf("192.168") > -1)
            //{
            //    //內網
            //    headingBackgroundManagement.Visible = true;
            //}
            //else
            //{
            //    //外網
            //}
        }
    }
}
