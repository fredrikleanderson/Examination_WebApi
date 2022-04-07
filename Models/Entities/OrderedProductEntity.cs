using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_WebApi.Models.Entities
{
    public class OrderedProductEntity
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual OrderEntity Order { get; set; } = null!;

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductEntity Product { get; set; } = null!;
    }
}
