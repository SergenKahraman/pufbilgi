using Puf.Data.Entity.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities
{
    [Table("Grades", Schema = "Categorization")]
    public class Grade : Entitybase
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

    }
}