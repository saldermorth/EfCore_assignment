namespace assignment_Dataaccess.Models
{
    public class CustomerForm //What the customer will enter
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int ZipCode { get; set; }
        public string City { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
