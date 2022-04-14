using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_WebApi.Models.Entities
{
    public class CartItemEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual ProductEntity Product { get; set; } = null!;

        [Required]
        [ForeignKey("Cart")]
        public int CartId { get; set; }

        public virtual CartEntity Cart { get; set; } = null!;
    }
}
