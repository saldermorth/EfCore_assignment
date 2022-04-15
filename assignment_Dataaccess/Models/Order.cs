namespace assignment_Dataaccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public DateTime OrderDate { get; set; }      
        public ICollection<OrderItem> OrderItem { get; set; } = null!;

    }
}
