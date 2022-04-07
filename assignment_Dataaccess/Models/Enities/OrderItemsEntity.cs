using System.ComponentModel.DataAnnotations;

namespace assignment_Dataaccess.Models.Enities
{
    public class OrderItemsEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public ProductsEntity Products { get; set; } = null!; //Fk to Producs Table
        [Required]
        public int Quantity { get; set; }
        //public OrderEntity Order { get; set; } = null!;//Fk from Orders table
    }
}
