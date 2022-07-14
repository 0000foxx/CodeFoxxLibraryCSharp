using System;
using System.Configuration;
using CodeFoxxLibrary.CallWebServiceLibrary;
using NUnit.Framework;

namespace CallWebServiceLibraryTestProject
{
    public class CallWebServiceManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_CallWebService_Success()
        {
            var callWebServiceManager = new CallWebServiceManager();
            string callWebServiceResult = callWebServiceManager.callWebService();
            Console.WriteLine("d1, callWebServiceResult = "+callWebServiceResult);

            Assert.AreEqual(true, !string.IsNullOrEmpty(callWebServiceResult));
        }
    }
}