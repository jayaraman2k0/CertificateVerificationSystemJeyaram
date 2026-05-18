namespace CertificateVerificationSystemJeyaram.Models
{
    public class StudentRecord
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EnrollmentNumber { get; set; } = string.Empty;
        public string Program { get; set; } = string.Empty;
        public DateTime Created { get; set; }

        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}