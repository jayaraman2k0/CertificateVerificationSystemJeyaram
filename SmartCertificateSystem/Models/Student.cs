using System.Collections.Generic;

namespace SmartCertificateSystem.Models
{
    // Student inherits from User
    public class Student : User
    {
        public double GPA { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Certificate> Certificates { get; set; } = new List<Certificate>();
        public List<Transcript> Transcripts { get; set; } = new List<Transcript>();

        public Student(string userId, string name, string email, string password, double gpa)
            : base(userId, name, email, password)
        {
            GPA = gpa;
        }

        // View certificate method
        public Certificate? ViewCertificate(string certificateId)
        {
            return Certificates.FirstOrDefault(c => c.CertificateId == certificateId);
        }
    }
}
