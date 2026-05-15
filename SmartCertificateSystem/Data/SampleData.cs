using SmartCertificateSystem.Models;

namespace SmartCertificateSystem.Data
{
    // Helper to create sample data for demo
    public static class SampleData
    {
        public static List<Student> GetSampleStudents()
        {
            var s1 = new Student("s1", "Alice Johnson", "alice@example.com", "alicepass", 3.8);
            s1.Certificates.Add(new Certificate(1, "C-1001", s1.Name, DateTime.UtcNow.AddYears(-1)));

            var s2 = new Student("s2", "Bob Smith", "bob@example.com", "bobpass", 3.4);
            s2.Certificates.Add(new Certificate(2, "C-1002", s2.Name, DateTime.UtcNow.AddYears(-2)));

            var s3 = new Student("s3", "Charlie Brown", "charlie@example.com", "charliepass", 3.9);
            s3.Certificates.Add(new Certificate(3, "C-1003", s3.Name, DateTime.UtcNow.AddYears(-3)));

            return new List<Student> { s1, s2, s3 };
        }
    }
}
