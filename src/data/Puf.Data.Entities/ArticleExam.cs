using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities
{
    [Table("ArticleExams", Schema = "Categorization")]
    public class ArticleExam
    {
        public Guid ArticleId { get; set; }
        public Guid ExamId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; }

        [ForeignKey(nameof(ExamId))]
        public virtual Exam Exam { get; set; }
    }
}