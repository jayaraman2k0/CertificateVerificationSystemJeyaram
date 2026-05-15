namespace SmartCertificateSystem.Models
{
    // Employer inherits from User and demonstrates method overloading
    public class Employer : User
    {
        public Employer(string userId, string name, string email, string password)
            : base(userId, name, email, password) { }

        // Verify by integer ID
        public bool VerifyCertificate(int certID)
        {
            // Simulate verification logic
            return certID > 0;
        }

        // Overloaded: verify by string ID and student name
        public bool VerifyCertificate(string certID, string studentName)
        {
            if (string.IsNullOrWhiteSpace(certID) || string.IsNullOrWhiteSpace(studentName))
                throw new ArgumentException("Invalid certificate or student name.");

            // Simulate verification
            return certID.StartsWith("C-") && studentName.Length > 0;
        }
    }
}
