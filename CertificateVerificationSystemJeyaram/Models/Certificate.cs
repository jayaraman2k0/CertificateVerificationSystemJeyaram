namespace CertificateVerificationSystemJeyaram.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public int StudentRecordId { get; set; }
        public StudentRecord? StudentRecord { get; set; }

        public string Title { get; set; } = string.Empty;
        public DateTime IssuedOn { get; set; }
        public string CertificateId { get; set; } = string.Empty; // unique id for verification
        public string FilePath { get; set; } = string.Empty; // where file is stored
        public bool IsApproved { get; set; }
    }
}