namespace CertificateVerificationSystemJeyaram.Models
{
    public class Transcript
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        // Subject + Grade mapping
        public Dictionary<string, double> Grades { get; set; } = new Dictionary<string, double>();

        public DateTime GeneratedDate { get; set; } = DateTime.Now;
    }

 }
