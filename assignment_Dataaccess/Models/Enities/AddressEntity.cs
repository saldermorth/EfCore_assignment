using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    public class AddressEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Street { get; set; } = null!;

        [Required]
        public int ZipCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;
        public virtual ICollection<CustomerEntity> Residents { get; set; } = null!; //FK to Customers table
    }
}
