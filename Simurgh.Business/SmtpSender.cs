using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Simurgh.Business
{
    public class SmtpSender : IMailSender
    {
        private SmtpClient _client;
        public bool Authenticate(string server, string userName, string password)
        {
            try
            {
                _client = new SmtpClient(server); //"m06.internetmailserver.net");
                _client.UseDefaultCredentials = false;
                _client.Credentials = new NetworkCredential(userName, password); //("admin@simurgh.com.au", "BestYear2019$");
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool SendPlain(string from, List<string> toList, string subject, string body)
        {
            try
            {
                if (_client == null)
                {
                    throw new Exception("Call authenticate first.");
                }

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from);

                foreach (var toEmail in toList)
                {
                    mailMessage.To.Add(toEmail);
                }

                mailMessage.Body = body;
                mailMessage.Subject = subject;
                _client.Send(mailMessage);

                return true;
            }
            catch (Exception e)
            {
                //log e.Message
                return false;
            }
        }
    }
}
