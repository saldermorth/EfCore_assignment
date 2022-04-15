using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    public class OrderItemsEntity
    {
       

        [Key, Column(Order = 0)]      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public virtual OrderEntity Order { get; set; } = null!;
        //public ProductsEntity ProductsListItem { get; set; } = null!; //Fk to Producs Table
        [Required]
        public int Quantity { get; set; }
        //public OrderEntity Order { get; set; } = null!;//Fk from Orders table
        
        public virtual Order_Item Order_Item { get; set; } = null!;
        public int? OrderItemId { get; set; }
    }
}
