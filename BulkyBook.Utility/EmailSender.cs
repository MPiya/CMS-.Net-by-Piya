using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
   public  class EmailSender : IEmailSender
    {
         public Task SendEmailAsync(string email,string subject, string htmlMessage)
        {
            //var emailToSend = new MimeMessage();
            //emailToSend.From.Add(MailboxAddress.Parse("hello@dotnetmastery.com"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            ////send email
            //using (var emailClient = new SmtpClient())
            //{
            //    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    emailClient.Authenticate("boncloth10@gmail.com", "Awakemode321");
            //    emailClient.Send(emailToSend);
            //    emailClient.Disconnect(true);

            //    return Task.CompletedTask;
            //}

            var mail = "bonissocool@hotmail.com";
                var pw = "Mpiyacs321";

            var client = new System.Net.Mail.SmtpClient("smtp.office365.com", 587)
            {

                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mail,pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject,
                                htmlMessage
                                ));
        }


    }
}
