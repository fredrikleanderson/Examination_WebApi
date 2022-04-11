using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

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
        public byte[] Hash { get; private set; } = null!;

        [Required]
        public byte[] Salt { get; private set; } = null!;

        public void CreatePassword(string password)
        {
            using var hmac = new HMACSHA512();
            Salt = hmac.Key;
            Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            hmac.Clear();
        }

        public bool CompareSecurePassword(string password)
        {
            using (var hmac = new HMACSHA512(Salt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != Hash[i])
                        return false;
                }
            }

            return true;
        }
    }
}
