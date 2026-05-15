namespace SmartCertificateSystem.Models
{
    // Base User class
    public abstract class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }

        protected User(string userId, string name, string email, string password)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
        }

        // Login method with basic validation
        public virtual bool Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Email or password cannot be empty.");

            if (Email.Equals(email, StringComparison.OrdinalIgnoreCase) && password == Password)
                return true;

            throw new UnauthorizedAccessException("Invalid credentials.");
        }
    }
}
