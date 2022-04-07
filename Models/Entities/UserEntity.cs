using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_WebApi.Models.Entities
{

    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = null!;

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public virtual AddressEntity Address { get; set; } = null!;

        [Required]
        public byte[] PasswordHash { get; private set; }

        [Required]
        public byte[] Salt { get; private set; }
    }
}
