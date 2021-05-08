using Microsoft.EntityFrameworkCore;
using Puf.Contracts.Management;
using Puf.Data.Context;
using Puf.Data.Entities;
using Puf.Services.Management.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Puf.Services.Management.Concretes
{
    public class WriterService : IWriterService
    {
        private readonly PufDbContext context;

        public WriterService(PufDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<WriterDto> GetListOfWriter(int count)
        {
            return context.Writers.Take(count).Select(w => new WriterDto
            {
                Description = w.Description,
                DisplayName = w.DisplayName,
                EmailAddress = w.MailAddress,
                Id = w.Id,
                Job = w.Job,
                PhotoId = w.DocumentId,
                City = w.City,
                SocialAccounts = context.SocialAccounts.Include(s => s.SocialType).Where(s => s.WriterId == w.Id).Select(s => new SocialAccountDto { Name = s.SocialType.Name, Url = s.Url }).ToList()

            });
        }


        public UserInfoDto Authenticate(string username, string password)
        {
            var hash = ComputeHash(password);
            var user = context.Writers.FirstOrDefault(f => f.UserName == username && f.Password == hash);
            if (user == null || !user.IsActive)
            {
                return null;
            }
            return new UserInfoDto
            {
                Id = user.Id,
                UserName = user.UserName,
                DisplayName = user.DisplayName
            };
        }


        private static string ComputeHash(string text)
        {
            var prefix = "_74YudhT63Hp0f!";
            var crypt = new SHA256Managed();
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(prefix + text));
            var builder = new StringBuilder();
            foreach (byte theByte in crypto)
            {
                builder.Append(theByte.ToString("x2"));
            }
            return builder.ToString();
        }

        public (bool isSuccess, Guid writerId, string code) Register(NewWriterDto newUser)
        {
            var verificationCode = $"{Guid.NewGuid():N}{Guid.NewGuid().ToString("N")}".Substring(0, 39);
            var _new = new Writer
            {
                Id = Guid.NewGuid(),
                IsActive = false,
                IsDeleted = false,
                City = newUser.City,
                Created = DateTime.Now,
                DisplayName = newUser.Name + newUser.firstName,
                Job = newUser.Job,
                MailAddress = newUser.EmailAddress,
                Password = "NEWUSER",
                Updated = DateTime.Now,
                UserName = newUser.UserName
            };
            context.Writers.Add(_new);
            var isSuccess = context.SaveChanges() > 1;
            return (isSuccess, _new.Id, verificationCode);
        }
    }
}
