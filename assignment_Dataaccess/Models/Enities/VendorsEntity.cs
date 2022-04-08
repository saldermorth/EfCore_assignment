using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    [Index(nameof(Name), IsUnique = true)]
    public class VendorsEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = null!;
        public virtual ICollection<ProductsEntity> CategoryProducts { get; set; } = null!; //Fk from Products table
    }
}
