using System.Collections.Generic;
using NUnit.Framework;
using CodeFoxxLibrary.EmailLibrary;
using NuGet.Frameworks;

namespace EmailLibraryTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void Test_EmailManager_SendEmailToMultiReceivers()
        {
            string senderEmailAddress = "guohao.zeng@winwayglobal.com";
            List<string> receiverEmailAddress = new List<string>(){"guohao.zeng@winwayglobal.com"};
            List<string> carbonCopyEmailAddress = new List<string>() { "guohao.zeng@winwayglobal.com" };
            string emailSubject = "test subject";
            string emailBody = "test body";

            EmailManager.SendEmailToMultiReceivers(senderEmailAddress, receiverEmailAddress,
                carbonCopyEmailAddress, emailSubject, emailBody);
        }

        [Test]
        public void Test_EmailManager_SendEmailToOneReceiver()
        {
            string senderEmailAddress = "guohao.zeng@winwayglobal.com";
            // string senderEmailAddress = null;
            string receiverEmailAddress = "guohao.zeng@winwayglobal.com";
            string carbonCopyEmailAddress = "guohao.zeng@winwayglobal.com";
            string emailSubject = "test subject";
            string emailBody = "test body";
                
            bool result = EmailManager.SendEmailToOneReceiver(senderEmailAddress, receiverEmailAddress, carbonCopyEmailAddress, emailSubject, emailBody);
            Assert.IsTrue(result);
        }
        
    }
}