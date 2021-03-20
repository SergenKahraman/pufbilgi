using Puf.Data.Entity.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puf.Data.Entities
{
    [Table("Documents", Schema = "Management")]

    public class Document : Entitybase
    {
        [Required]
        [MaxLength(255)]
        public string PhysicalAddress { get; set; }
    }
}