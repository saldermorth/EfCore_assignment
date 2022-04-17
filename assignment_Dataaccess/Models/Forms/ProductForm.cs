using assignment_Dataaccess.Models.Enities;

namespace assignment_Dataaccess.Models.Forms
{
    public class ProductForm
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string VendorName { get; set; } = null!;
        


    }
}
