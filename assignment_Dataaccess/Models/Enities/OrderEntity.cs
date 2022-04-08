using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    public class OrderEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public CustomerEntity Customers { get; set; } = null!; //FK to Customer table
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual ICollection<ProductsEntity> Products { get; set; } = null!; //FK from Products table
        [Required]
        public int OrderItemId { get; set; }
        public virtual ICollection<OrderItemsEntity> CartItem { get; set; } = null!; 
    }
}
