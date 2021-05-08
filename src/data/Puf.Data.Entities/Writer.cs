using Puf.Data.Entity.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities  //Doğrulama mailine tıklayana kadar pasif kalır
{
    [Table("Writers", Schema = "Management")]
    public class Writer : Entitybase
    {
        [Required]
        [MaxLength(40)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(60)]
        public string DisplayName { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }

        [Required]
        [MaxLength(64)]
        public string MailAddress { get; set; }

        [MaxLength(64)]
        public string Job { get; set; }

        [MaxLength(240)]
        public string Description { get; set; }

        [MaxLength(24)]
        public string City { get; set; }

        [MaxLength(40)]
        public string VerificationCode { get; set; }

        public Guid? DocumentId { get; set; }

        [ForeignKey(nameof(DocumentId))]
        public virtual Document Document { get; set; }
    }
}