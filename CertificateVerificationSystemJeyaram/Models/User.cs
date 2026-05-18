namespace CertificateVerificationSystemJeyaram.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public virtual void Login(string email, string password)
        {
            // Basic login placeholder
            Console.WriteLine("User login successful");
        }
    }
}
