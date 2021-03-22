using Puf.Contracts.Management;
using Puf.Data.Context;
using Puf.Services.Management.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
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
                PhotoId = w.DocumentId

            }).ToList();
        }
    }
}
