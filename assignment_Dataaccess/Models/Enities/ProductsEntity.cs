using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProductsEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public int? CategoryId { get; set; }
        public CategorysEntity Category { get; set; } = null!; //Fk to categorys table
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Required]        
        public int PriceId { get; set; }
        public virtual PriceListEntity Price { get; set; } = null!; //Fk from PriceList table
        [Required]
        public int Stock { get; set; }
        public virtual OrderEntity Order { get; set; } = null!; //Fk from Order table
        public int VendorId { get; set; }
        public virtual VendorsEntity Vendors { get; set; } = null!; //Fk to Vendors table


    }
}
