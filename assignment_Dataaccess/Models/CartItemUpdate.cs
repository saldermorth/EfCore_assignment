namespace assignment_Dataaccess.Models
{
    public class CartItemUpdate
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity{ get; set; }
    }
}
