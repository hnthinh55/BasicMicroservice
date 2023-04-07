using Domain.Common;
using Domain.DTO;
using Domain.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.SendMailService
{
    public class MailService : IMailService
    {
        private readonly EmailConfiguration emailConfiguration;
        public MailService(IOptions<EmailConfiguration> emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailConfiguration.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if(mailRequest.Attachments!= null)
            {
                byte[] fileBytes;
                foreach(var attachment in mailRequest.Attachments)
                {
                    if (attachment.Length > 0)
                    {
                        using(var stream = new MemoryStream())
                        {
                            attachment.CopyTo(stream);
                            fileBytes= stream.ToArray();
                        }
                        builder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                    }
                }
            }

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(emailConfiguration.Host, emailConfiguration.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailConfiguration.Mail, emailConfiguration.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
