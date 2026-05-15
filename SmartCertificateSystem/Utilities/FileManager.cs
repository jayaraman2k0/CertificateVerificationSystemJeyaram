using SmartCertificateSystem.Models;

namespace SmartCertificateSystem.Utilities
{
    // File handling utilities for certificates and transcripts
    public static class FileManager
    {
        // Write sample certificates to a file
        public static void WriteCertificates(string filePath, List<Student> students)
        {
            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var sw = new StreamWriter(fs);
            foreach (var s in students)
            {
                foreach (var c in s.Certificates)
                {
                    sw.WriteLine($"{c.Id}|{c.CertificateId}|{c.StudentName}|{c.IssueDate:O}");
                }
            }
        }

        // Read certificates from file
        public static List<Certificate> ReadCertificates(string filePath)
        {
            var list = new List<Certificate>();
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                var parts = line.Split('|');
                if (parts.Length >= 4)
                {
                    list.Add(new Certificate(int.Parse(parts[0]), parts[1], parts[2], DateTime.Parse(parts[3])));
                }
            }
            return list;
        }
    }
}
