using Microsoft.Extensions.Options;
using Puf.Common.Contracts;
using Puf.Data.Context;
using Puf.Services.Management.Abstraction;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Puf.Services.Management.Concretes
{
    public class MailService : IMailService
    {
        private readonly PufDbContext context;
        private readonly Settings.MailConfiguration mailConfiguration;


        public MailService(PufDbContext context, IOptions<Settings> options)
        {
            this.context = context;
            mailConfiguration = options.Value.Mail;

        }
        public void SendVerificationMail(Guid writerId, string content)
        {
            var EmailAddress = context.Writers.Where(f => f.Id == writerId && !f.IsActive)
                            .Select(i => i.EmailAddress)
                            .FirstOrDefault();
            if (string.IsNullOrEmpty(EmailAddress))
            {
                return;
            }

            var client = new SmtpClient
            {
                Host = mailConfiguration.Server,
                Timeout = 30000,
                Credentials = new NetworkCredential(mailConfiguration.User, mailConfiguration.Password),
                EnableSsl = true,
                Port = 587
            };

            var mail = new MailMessage(new MailAddress(mailConfiguration.User, "Puf Bilgi"), new MailAddress(EmailAddress))
            {
                Body = content,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true,
                Subject = "Puf Bilgi Yeni Üyelik",
                SubjectEncoding = Encoding.UTF8
            };
            client.Send(mail);
        }
    }
}
