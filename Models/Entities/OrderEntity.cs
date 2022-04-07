using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_WebApi.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderRecieved { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20")]
        public string OrderStatus { get; set; } = null!;

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual UserEntity User { get; set; } = null!;
    }
}
