using assignment_Dataaccess.Models.Enities;

namespace assignment_Dataaccess.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;    
       public AddressEntity Address { get; set; } = null!;
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();    

    }
}
