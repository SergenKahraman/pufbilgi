using Puf.Data.Entity.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities
{
    [Table("SocialAccounts", Schema = "Management")]
    public class SocialAccount : Entitybase
    {
        [Required]
        public Guid WriterId { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public Guid TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public virtual SocialType SocialType { get; set; }

        [ForeignKey(nameof(WriterId))]
        public virtual Writer Writer { get; set; }
    }
}