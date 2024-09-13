using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DSS_Website
{
    public class ClientMessage
    {
        public string ClientNames { get; set; }
        public string ClientEmail { get; set; }
        public string ClientSubject { get; set; }
        public string ClientQuery { get; set; }

        public ClientMessage(string clientName, string clientEmail, string clientSubject, string clientQuery)
        {
            this.ClientNames = clientName;
            this.ClientEmail = clientEmail;
            this.ClientSubject = clientSubject;
            this.ClientQuery = clientQuery;
        }
        public void SendQuery()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                };
                client.Credentials = new NetworkCredential("217077755@student.uj.ac.za", "UJ--0nyaka'ng?");
                MailMessage message = new MailMessage();
                message.To.Add("217077755@student.uj.ac.za");
                message.From = new MailAddress("217077755@student.uj.ac.za");
                message.Subject = ClientSubject;
                message.Body = $"Client email: {ClientEmail}\n";
                message.Body += $"Client name(s): {ClientNames}\n\n";
                message.Body += $"Client query:\n {ClientQuery}";
                client.Send(message);
                client.Dispose();
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}