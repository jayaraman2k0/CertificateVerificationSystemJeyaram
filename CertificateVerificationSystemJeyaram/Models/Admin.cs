using System;
using System.Collections.Generic;
using System.Linq;

namespace CertificateVerificationSystemJeyaram.Models
{
    public class Admin : User
    {
        // Admin-specific operations working on in-memory student collections
        public Admin() { }

        public void AddStudent(List<Student> students, Student student)
        {
            if (students == null) throw new ArgumentNullException(nameof(students));
            students.Add(student);
        }

        public void UpdateStudent(List<Student> students, int userId, string name)
        {
            if (students == null) throw new ArgumentNullException(nameof(students));
            var s = students.FirstOrDefault(x => x.UserId == userId);
            if (s != null)
                s.Name = name;
        }

        public void DeleteStudent(List<Student> students, int userId)
        {
            if (students == null) throw new ArgumentNullException(nameof(students));
            var s = students.FirstOrDefault(x => x.UserId == userId);
            if (s != null)
                students.Remove(s);
        }

        public void ViewStudents(IEnumerable<Student> students)
        {
            if (students == null) return;
            foreach (var s in students)
            {
                Console.WriteLine($"{s.UserId} - {s.Name} - GPA: {s.GPA}");
            }
        }
    }
}
