using System;
using CodeFoxxLibrary.NetworkLibrary;
using NUnit.Framework;

namespace NetworkLibraryTestProject
{
    [TestFixture]
    public class NetworkManagerTests
    {
        [Test]
        public void CheckIntranetOrInternet_Intranet_ReturnTrue()
        {
            NetworkManager.NetType expectIntranet = NetworkManager.CheckIntranetOrInternet("192.168.1.1");
            Assert.AreEqual(expectIntranet, NetworkManager.NetType.INTRANET);
        }

        [Test]
        public void GetLocalIP_Normal_returnLocalIP()
        {
            string localIP = NetworkManager.GetLocalIP();
            Console.WriteLine($"d1, localIP = {localIP}");
        }
    }
}