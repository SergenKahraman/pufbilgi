using Puf.Data.Entity.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities
{
    [Table("ArticleMeta", Schema = "Content")]
    public class ArticleMeta : Entitybase
    {
        [Required]
        public Guid ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(400)]
        [Required]
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }

        public Guid? PreViewPhotoId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; }

        [ForeignKey(nameof(PreViewPhotoId))]
        public virtual Document Document { get; set; }
    }
}