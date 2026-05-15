namespace SmartCertificateSystem.Models
{
    // Admin inherits from User and can manage student records
    public class Admin : User
    {
        public Admin(string userId, string name, string email, string password)
            : base(userId, name, email, password) { }

        public void ManageStudentRecords(List<Student> students)
        {
            // Simple display management action
            Console.WriteLine("Managing student records... Total students: " + students.Count);
        }
    }
}
