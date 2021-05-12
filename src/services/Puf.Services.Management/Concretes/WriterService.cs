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
                EmailAddress = w.EmailAddress,
                Id = w.Id,
                Job = w.Job,
                PhotoId = w.DocumentId,
                City = w.City,
                SocialAccounts = context.SocialAccounts.Include(s => s.SocialType).Where(s => s.WriterId == w.Id).Select(s => new SocialAccountDto { Name = s.SocialType.Name, Url = s.Url }).ToList()

            });
        }

        public WriterDto GetWriter(Guid Id)
        {
            return context.Writers.Include(w => w.Document).Where(w => w.Id == Id).Select(w => new WriterDto
            {
                Id = w.Id,
                City = w.City,
                Description = w.Description,
                DisplayName = w.DisplayName,
                EmailAddress = w.EmailAddress,
                Job = w.Job,
                PhotoId = w.DocumentId,
                SocialAccounts = context.SocialAccounts.Include(s => s.SocialType).Where(s => s.WriterId == w.Id).Select(s => new SocialAccountDto { Name = s.SocialType.Name, Url = s.Url }).ToList()
            }).FirstOrDefault();
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

        public bool CheckIfCodeAndUserExists(string code, Guid writerId)
        {
            var result = context.Writers.Any(a => a.VerificationCode == code && a.Id == writerId);
            if (result)
            {
                var writer = context.Writers.Single(w => w.Id == writerId);
                writer.IsActive = true;
                return context.SaveChanges() > 0;
            }
            return false;


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
                DisplayName = newUser.FirstName + " " + newUser.LastName,
                Job = newUser.Job,
                EmailAddress = newUser.EmailAddress,
                Password = ComputeHash(newUser.Password),
                Updated = DateTime.Now,
                UserName = newUser.UserName,
                VerificationCode = verificationCode
            };
            context.Writers.Add(_new);
            var isSuccess = context.SaveChanges() > 0;
            return (isSuccess, _new.Id, verificationCode);
        }



        public bool UpdateWriter(WriterDto writerDto)
        {
            var writer = context.Writers.FirstOrDefault(w => w.Id == writerDto.Id);
            writer.City = writerDto.City;
            writer.Description = writerDto.Description ?? "";
            writer.DisplayName = writerDto.DisplayName;
            writer.EmailAddress = writerDto.EmailAddress;
            writer.Job = writerDto.Job;
            writer.Updated = DateTime.Now;
            var result1 = context.SaveChanges() > 0;

            var socialAccounts = context.SocialAccounts.Include(s => s.SocialType).Where(s => s.WriterId == writerDto.Id).ToList();
            foreach (var item in writerDto.SocialAccounts)
            {
                var _socialAccount = socialAccounts.FirstOrDefault(w => w.SocialType.Name == item.Name);
                if (_socialAccount != null)
                {
                    _socialAccount.Url = item.Url;
                }
                else
                {
                    var newSocialAccount = new SocialAccount
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now,
                        IsActive = true,
                        IsDeleted = false,
                        TypeId = context.SocialTypes.First(w => w.Name == item.Name).Id,
                        Updated = DateTime.Now,
                        Url = item.Url,
                        WriterId = writerDto.Id
                    };
                    context.SocialAccounts.Add(newSocialAccount);
                    
                }
            }
            context.SaveChanges();


            return result1;
            
                
           

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

        
    }
}
