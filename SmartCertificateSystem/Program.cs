using SmartCertificateSystem.Models;
using SmartCertificateSystem.Services;
using SmartCertificateSystem.Utilities;
using SmartCertificateSystem.Data;

// Program entry for Smart Certificate System Console App
Console.WriteLine("Smart Certificate Verification System - Demo");

// Initialize sample data and services
var students = SampleData.GetSampleStudents();
var admin = new Admin("admin1", "Admin User", "admin@example.com", "adminpass");
var employer = new Employer("emp1", "Employer User", "employer@example.com", "emppass");

// Simple login simulation
try
{
    admin.Login("admin@example.com", "adminpass");
    Console.WriteLine($"{admin.Name} logged in.");
}
catch (Exception ex)
{
    Console.WriteLine($"Login failed: {ex.Message}");
}

// Certificate verification demo
try
{
    var certsFile = "certificates.txt";
    FileManager.WriteCertificates(certsFile, students);
    var found = employer.VerifyCertificate(1);
    Console.WriteLine(found ? "Certificate verified by ID." : "Certificate verification failed by ID.");

    var found2 = employer.VerifyCertificate("C-1002", "Alice Johnson");
    Console.WriteLine(found2 ? "Certificate verified by name." : "Certificate verification failed by name.");
}
catch (FileNotFoundException fex)
{
    Console.WriteLine($"File error: {fex.Message}");
}

// Sorting students by GPA
Console.WriteLine("\nStudents sorted by GPA (desc):");
var sorted = students.OrderByDescending(s => s.GPA).ToList();
foreach (var s in sorted)
    Console.WriteLine($"{s.Name} - GPA: {s.GPA}");

// LINQ queries
Console.WriteLine("\nStudents with GPA > 3.5:");
var topStudents = students.Where(s => s.GPA > 3.5);
foreach (var ts in topStudents)
    Console.WriteLine($"{ts.Name} - {ts.GPA}");

// Simulated DB operations
var db = new DatabaseManager();
db.Create();
db.Read();

Console.WriteLine("Demo complete. Press any key to exit.");
Console.ReadKey();
