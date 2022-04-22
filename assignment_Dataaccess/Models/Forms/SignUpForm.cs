namespace assignment_Dataaccess.Models.Forms
{
    public class SignUpForm
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; }
        public string Password { get; set; } = null!;
    }
}
