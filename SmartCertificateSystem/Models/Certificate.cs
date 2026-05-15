namespace SmartCertificateSystem.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string CertificateId { get; set; }
        public string StudentName { get; set; }
        public DateTime IssueDate { get; set; }

        public Certificate(int id, string certificateId, string studentName, DateTime issueDate)
        {
            Id = id;
            CertificateId = certificateId;
            StudentName = studentName;
            IssueDate = issueDate;
        }
    }
}
