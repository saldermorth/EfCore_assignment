using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    [Index(nameof(Name), IsUnique = true)]
    public class CategorysEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = null!;
        public ICollection<ProductsEntity> Products { get; set; } = null!; // Fk from products table
    }
}
