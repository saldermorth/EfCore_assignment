using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual AddressEntity Address { get; set; } = null!; // FK to address table
        public ICollection<OrderEntity> Orders { get; set; } = null!; // FK from orders table

    }
}
