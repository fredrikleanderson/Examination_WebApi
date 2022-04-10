using System.ComponentModel.DataAnnotations;

namespace Examination_WebApi.Models.Entities
{
    public class InventoryEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual ProductEntity Product { get; set; } = null!;
    }
}
