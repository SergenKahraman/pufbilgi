using Puf.Data.Entity.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities
{
    [Table("Articles", Schema = "Content")]
    public class Article : Entitybase
    {
        public int? LikeCount { get; set; }

        [Required]
        public string HtmlContent { get; set; }

        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public Guid WriterId { get; set; }

        [ForeignKey(nameof(WriterId))]
        public virtual Writer Writer { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }

    }
}