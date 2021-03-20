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

        [Required]
        public Guid ExamId1 { get; set; }

        public Guid? ExamId2 { get; set; }
        public Guid? ExamId3 { get; set; }
        public Guid? ExamId4 { get; set; }
        public Guid? ExamId5 { get; set; }

        [ForeignKey(nameof(LessonId))]
        public virtual Lesson Lesson { get; set; }

        [ForeignKey(nameof(GradeId))]
        public virtual Grade Grade { get; set; }

        [ForeignKey(nameof(ExamId1))]
        public virtual Exam Exam1 { get; set; }

        [ForeignKey(nameof(ExamId2))]
        public virtual Exam Exam2 { get; set; }

        [ForeignKey(nameof(ExamId3))]
        public virtual Exam Exam3 { get; set; }

        [ForeignKey(nameof(ExamId4))]
        public virtual Exam Exam4 { get; set; }

        [ForeignKey(nameof(ExamId5))]
        public virtual Exam Exam5 { get; set; }
    }
}