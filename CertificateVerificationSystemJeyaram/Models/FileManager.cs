namespace CertificateVerificationSystemJeyaram.Models
{
    using System;
    using System.IO;

    namespace SmartCertificateSystem
    {
        class FileManager
        {
            string folderPath = @"C:\StudentFiles";

            // Create Directory
            public void CreateDirectory()
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);

                    Console.WriteLine("Folder Created");
                }
                else
                {
                    Console.WriteLine("Folder Already Exists");
                }
            }

            // Save Certificate File
            public void SaveCertificate(string studentName, string content)
            {
                string filePath = folderPath + "\\" + studentName + "_Certificate.txt";

                FileStream fs = new FileStream(filePath, FileMode.Create);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(content);

                sw.Close();
                fs.Close();

                Console.WriteLine("Certificate Saved");
            }

            // Read Certificate File
            public void ReadCertificate(string studentName)
            {
                string filePath = folderPath + "\\" + studentName + "_Certificate.txt";

                if (File.Exists(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);

                    StreamReader sr = new StreamReader(fs);

                    string data = sr.ReadToEnd();

                    Console.WriteLine("\nCertificate Content:");
                    Console.WriteLine(data);

                    sr.Close();
                    fs.Close();
                }
                else
                {
                    Console.WriteLine("File Not Found");
                }
            }
        }

    }

}
    