using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    public class PriceListEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "char(3)")]
        public string CurrencyCode { get; set; } = null!;
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        public DateTime Modified { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual ProductsEntity Products { get; set; } = null!;

    }
}
