using System;

namespace Puf.Contracts.Management
{
    public class WriterDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public Guid? PhotoId { get; set; }
    }
}