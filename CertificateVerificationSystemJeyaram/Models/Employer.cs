using System;
using System.Collections.Generic;

namespace CertificateVerificationSystemJeyaram.Models
{
    public class Employer : User
    {
        public string CompanyName { get; set; } = string.Empty;

        public Employer()
        {
            // role property is optional on User; this is illustrative
        }

        // Simple verification by certificate numeric id (simulated)
        public bool VerifyCertificateById(int certId, IEnumerable<Certificate> certificates)
        {
            if (certificates == null) return false;
            return certificates.Any(c => c.Id == certId && c.IsApproved);
        }

        // Overloaded verification by certificate string id and student name
        public bool VerifyCertificateByDetails(string certificateId, string studentName, IEnumerable<Certificate> certificates)
        {
            if (string.IsNullOrWhiteSpace(certificateId) || string.IsNullOrWhiteSpace(studentName))
                return false;

            return certificates.Any(c => c.CertificateId == certificateId &&
                                          c.StudentRecord != null &&
                                          (c.StudentRecord.FirstName + " " + c.StudentRecord.LastName).Equals(studentName, StringComparison.OrdinalIgnoreCase) &&
                                          c.IsApproved);
        }

        // Display transcript details
        public void ViewTranscript(Transcript t)
        {
            if (t == null) return;
            Console.WriteLine($"Transcript for: {t.StudentName} (Generated: {t.GeneratedDate})");
            foreach (var kv in t.Grades)
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
        }
    }
}
