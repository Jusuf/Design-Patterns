using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Singelton.Core.TaskManager
{
    class SendEmailTask : ITask
    {
        private const string From = "you@yourdomain.com";
        private const string UserName = "user@ymail.com";
        private const string Password = "password";
        private const string Host = "smtp";
        private const int Port = 587; // 25?

        private readonly string subject;
        private readonly string message;
        private readonly string to;

        public SendEmailTask(string subject, string message, string to)
        {
            this.subject = subject;
            this.message = message;
            this.to = to;
        }

        public void Execute()
        {
            var mail = new MailMessage(From, to);
            var client = new SmtpClient
            {
                Port = Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(UserName, Password),
                Host = Host
            };

            mail.Subject = subject;
            mail.Body = message;

            try
            {
                client.Send(mail);
            }
            catch (Exception exception)
            {
                //throw Log;
            }
        }
    }
}
