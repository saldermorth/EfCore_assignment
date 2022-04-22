namespace assignment_Dataaccess.Models.Forms
{
    public class LoginForm
    {
        public int CustomerId { get; set; }
        public int Email { get; set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] Salt { get; private set; }

    }
}
