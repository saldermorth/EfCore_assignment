namespace assignment_Dataaccess.Models
{
    public class OrderUpdateEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        
        public ICollection<CartItemUpdate> cartitems { get; set; } = null!;

    }
}
