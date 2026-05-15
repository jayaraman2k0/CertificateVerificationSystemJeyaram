namespace CertificateVerificationSystemJayaram.Models
{
    public class VerificationLog
    {
        public int Id { get; set; }
        public string CertificateId { get; set; } = string.Empty;
        public DateTime CheckedOn { get; set; }
        public string? CheckedByIp { get; set; }
        public bool IsValid { get; set; }
    }
}