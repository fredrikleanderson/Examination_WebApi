using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_WebApi.Models.Entities
{

    [Index(nameof(Name), IsUnique = true)]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductEntity>? Products { get; set; }
    }
}
