namespace assignment_Dataaccess.Models.Forms
{
    public class OrderForm
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public ICollection<OrderItemEntity> OrderItem { get; set; } = null!;
        public DateTime OrderDate { get; set; }



    }
}
