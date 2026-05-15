using System.Data;
using System.Data.SqlClient;
using SmartCertificateSystem.Models;

namespace SmartCertificateSystem.Services
{
    // Simulated/Lightweight Database manager demonstrating CRUD and SQL strings
    public class DatabaseManager
    {
        // In production this would be a connection string
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SmartCertDemo;Trusted_Connection=True;";

        public void Create()
        {
            try
            {
                Console.WriteLine("[DB] Creating tables (simulated)...");
                // Example SQL
                var sql = "CREATE TABLE Students (Id INT, Name NVARCHAR(200))";
                Console.WriteLine("SQL: " + sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Create Error: " + ex.Message);
            }
        }

        public void Read()
        {
            try
            {
                Console.WriteLine("[DB] Reading data (simulated)...");
                // Example SQL
                var sql = "SELECT * FROM Students";
                Console.WriteLine("SQL: " + sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Read Error: " + ex.Message);
            }
        }

        public void Update()
        {
            try
            {
                Console.WriteLine("[DB] Updating data (simulated)...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Update Error: " + ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                Console.WriteLine("[DB] Deleting data (simulated)...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Delete Error: " + ex.Message);
            }
        }
    }
}
