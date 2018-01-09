using System.Configuration;
using System.Net.Mail;

namespace ReleaseWITAlert.Lib
{
    internal class EmailServer : IEmailServer
    {
        public void SendEmail(string message)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var client = new SmtpClient
            {
                Host = appSettings["SMTPServer"]
            };

            var from = new MailAddress(appSettings["SMTPServerFromAddress"]);
            var to = new MailAddress(appSettings["SMTPServerToAddress"]);

            var msg = new MailMessage
            {
                From = from,
                To = {to},
                Body = message,
                Subject = "Work Items have changed for the tags you are tracking!"
            };

            client.Send(msg);
        }
    }
}
