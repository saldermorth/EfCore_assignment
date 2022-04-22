using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace assignment_Dataaccess.Models.Enities
{

    [Index(nameof(Email), IsUnique = true)]

    public class CustomerEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; } = null!;

        [Required]
        public int AddressId { get; set; }
        [Required]
        public byte[] PasswordHash { get; private set; } = null!;
        [Required]
        public byte[] Salt { get; private set; } = null!;
        public virtual AddressEntity Address { get; set; } = null!; // FK to address table
        public ICollection<OrderEntity>? Orders { get; set; } = null!; // FK from orders table

        public void CreateSecurePassword(string password) {
            using var hmac = new HMACSHA512();
            Salt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            hmac.Clear();        
        }
        public bool CompareSecurePassword(string password)
        {
            using (var hmac = new HMACSHA512(Salt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != PasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
    }
}
