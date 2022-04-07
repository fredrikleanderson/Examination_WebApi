using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_WebApi.Models.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StreetAddress { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50")]
        public string City { get; set; } = null!;
    }
}
