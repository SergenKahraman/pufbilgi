using System;
using System.Collections.Generic;

namespace Puf.Contracts.Management
{
    public class WriterDto
    {
        public WriterDto()
        {
            SocialAccounts = new List<SocialAccountDto>();
        }
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public List<SocialAccountDto> SocialAccounts { get; set; }
        public Guid? PhotoId { get; set; }
    }

    public class SocialAccountDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}