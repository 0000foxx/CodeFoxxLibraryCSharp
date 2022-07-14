using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CodeFoxxLibrary.EmailLibrary
{
    public class EmailManager
    {
        public static void SendEmailToMultiReceivers(string senderEmailAddress, List<string> receiversEmailAddress,
            List<string> carbonsEmailAddress, string subject, string body)
        {
            MailMessage mailToSend = new MailMessage();
            mailToSend.IsBodyHtml = true;

            mailToSend.From = new MailAddress(senderEmailAddress);
            receiversEmailAddress.ForEach(to => mailToSend.To.Add(to));
            carbonsEmailAddress.ForEach(cc => mailToSend.CC.Add(cc));
            mailToSend.Subject = subject;
            mailToSend.Body = body;

            using (SmtpClient client = new SmtpClient("mailhub.winwayglobal.com", 25))
            {
                client.Send(mailToSend);
            }
        }

        public static bool SendEmailToOneReceiver(string senderEmailAddress,
            string receiverEmailAddress, string carbonCopyEmailAddress, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;

                mail.From = new MailAddress(senderEmailAddress);
                mail.To.Add(new MailAddress(receiverEmailAddress));
                mail.CC.Add(new MailAddress(carbonCopyEmailAddress));

                mail.Subject = subject;
                mail.Body = body;

                using (SmtpClient client = new SmtpClient("mailhub.winwayglobal.com", 25))
                {
                    client.Send(mail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

    }
}
