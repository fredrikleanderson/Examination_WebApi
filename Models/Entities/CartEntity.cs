using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_WebApi.Models.Entities
{
    public class CartEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        public virtual UserEntity User { get; set; } = null!;
        public virtual ICollection<CartItemEntity> CartItems { get; set; } = null!;
    }
}
