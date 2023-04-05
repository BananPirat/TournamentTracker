using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using TournamentTracker;
using System.Net;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void TestEmail()
        {
            var fromAddress = new MailAddress("sender@bruh.online", "bruh");
            var toAddress = new MailAddress("bruhhh@bruh.online", "Recipient bruh");
            const string fromPassword = "password";
            const string subject = "Test email";
            const string body = "This is a test email.";

            var smtp = new SmtpClient
            {
                Host = "127.0.0.1",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
        /// <summary>
        /// Primary Send Email method, used to send e-mails to single individuals.
        /// </summary>
        public static void SendEmail(string to, string subject, string body)
        {
            SendEmail(new List<string> { to }, new List<string> { }, subject, body);
        }

        /// <summary>
        /// Secondary Send Email method, used to send the final e-mail at tournament's conclusion (includes BCC list).
        /// </summary>
        public static void SendEmail(List<string> to, List<string> bcc, string subject, string body)
        {
            //TestEmail();
            MailAddress fromMailAddress = new(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("displayName"));

            MailMessage mail = new();
            foreach (string email in to)
            {
                mail.To.Add(email);
            }
            foreach (string email in bcc)
            {
                mail.Bcc.Add(email);
            }
            mail.From = fromMailAddress;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient client = new();

            //client.Send(mail);
        }
    }
}