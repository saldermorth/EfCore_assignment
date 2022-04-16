namespace assignment_Dataaccess.Models
{
    public class OrderItem
    {
        public int Id { get; set; } 
        public int ProductsID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public Order Order { get; set; }

    }
}
