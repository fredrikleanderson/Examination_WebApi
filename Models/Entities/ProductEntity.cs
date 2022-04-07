using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_WebApi.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; } = null!;
    }
}
