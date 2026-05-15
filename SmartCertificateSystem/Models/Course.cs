namespace SmartCertificateSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public Course(int id, string name)
        {
            CourseId = id;
            CourseName = name;
        }
    }
}
