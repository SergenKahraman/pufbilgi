using Puf.Data.Entity.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities
{
    [Table("SocialTypes", Schema = "Management")]
    public class SocialType : Entitybase
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        public Guid DocumentId { get; set; }

        [ForeignKey(nameof(DocumentId))]
        public virtual Document Document { get; set; }
    }
}