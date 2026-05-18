namespace CertificateVerificationSystemJeyaram.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ModuleName { get; set; }

        // Students enrolled in this course
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();

        // Optional: Course credits (useful for GPA system)
        public int Credits { get; set; }

    }

    }
