using assignment_Dataaccess.Models.Enities;

namespace assignment_Dataaccess.Models.Forms
{
    public class OrderForm
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public string OrderStatus { get; set; } = "Not set";
        public ICollection<CartItemUpdate> OrderItem { get; set; } = null!;
        public DateTime OrderDate { get; set; }


    }
}
