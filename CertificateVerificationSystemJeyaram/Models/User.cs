namespace CertificateVerificationSystemJayaram.Models
{
    public class User
    {
            public int UserId { get; set; }
            public required string Name { get; set; }
            public required string Email { get; set; }

            public virtual void Login(string email, string password)
            {
                Console.WriteLine("User login successful");
            }
        }
    }
