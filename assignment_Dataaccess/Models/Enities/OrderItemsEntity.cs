using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    public class OrderItemsEntity
    {
        [Key, Column(Order = 0)]
       
        [ForeignKey("Products")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual ProductsEntity Products { get; set; } = null!; //Fk to Producs Table
        [Required]
        public int Quantity { get; set; }
        //public OrderEntity Order { get; set; } = null!;//Fk from Orders table
    }
}
