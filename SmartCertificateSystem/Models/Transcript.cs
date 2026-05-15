namespace SmartCertificateSystem.Models
{
    public class Transcript
    {
        public int TranscriptId { get; set; }
        public double GPA { get; set; }

        public Transcript(int id, double gpa)
        {
            TranscriptId = id;
            GPA = gpa;
        }
    }
}
