namespace CertificateVerificationSystemJeyaram.Models
{

    public class Student : User
    {
        // Student-specific properties
        public required string DateOfBirth { get; set; }
        public double GPA { get; set; }
    }

    // Admin and Employer are defined in their own files
}

