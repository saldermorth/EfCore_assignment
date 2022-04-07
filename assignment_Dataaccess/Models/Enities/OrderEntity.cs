using System.ComponentModel.DataAnnotations;

namespace assignment_Dataaccess.Models.Enities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public CustomerEntity Customers { get; set; } = null!; //FK to Customer table
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int ProductId { get; set; }
        public ICollection<ProductsEntity> Products { get; set; } = null!; //FK from Products table
        [Required]
        public int OrderItemId { get; set; }
        public ICollection<OrderItemsEntity> CartItem { get; set; } = null!; 
    }
}
