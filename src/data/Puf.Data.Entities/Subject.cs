using Puf.Data.Entity.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities
{
    [Table("Subjects", Schema = "Categorization")]
    public class Subject : Entitybase
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public Guid LessonId { get; set; }

        [Required]
        public Guid GradeId { get; set; }

        [ForeignKey(nameof(LessonId))]
        public virtual Lesson Lesson { get; set; }

        [ForeignKey(nameof(GradeId))]
        public virtual Grade Grade { get; set; }
    }
}