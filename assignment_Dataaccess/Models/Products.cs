using assignment_Dataaccess.Models.Enities;

namespace assignment_Dataaccess.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        
        public Vendors Vendors { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}
