using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using OrdenesCore.Interfaces;

namespace OrdenesInfraestructure.Emails
{
    public class SendEmails : ISendEmails
    {

        private string _smtp;

        public SendEmails()
        {

        }

       public async Task<bool> SendEmail(string sender, string body)
        {
           var smtp2 = new SmtpClient("smtp.gmail.com", 587);
            smtp2.UseDefaultCredentials = false;
            smtp2.Credentials = new NetworkCredential("demokallsony@gmail.com", "******");
            smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("demokallsony@gmail.com", "K ALL SONY");
            mail.To.Add(new MailAddress(sender));
            mail.Subject = "ESTADO DE ORDEN DE COMPRA";
            mail.IsBodyHtml = true;
            mail.Body = body;

            smtp2.EnableSsl = true;

            try
            {
                await smtp2.SendMailAsync(mail);
                return true;
            }
            catch (SmtpException e)
            {
                Console.WriteLine("Error: {0}", e.StatusCode);
                return false;
            }
            

          

        }

    }
}
