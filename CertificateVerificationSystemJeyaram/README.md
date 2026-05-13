# Smart Certificate Verification and Student Records Management System

This project is a sample ASP.NET Core MVC application for managing student records and verifying certificates. It includes role-based authentication (Admin, Student, Employer), file uploads, certificate verification, and reporting.

Features:
- Identity with roles (Admin, Student, Employer)
- Admin dashboard: manage students, upload certificates, approve, and generate simple reports
- File uploads for certificates (stored in wwwroot/uploads)
- Public verification page to verify certificate by unique ID
- Basic views using Bootstrap

Running
1. Update `appsettings.json` connection string if you want to use a specific SQL Server instance.
2. Run the application in Visual Studio. The database will be created automatically using EF Core migrations.
3. Default admin credentials are defined in configuration or seeded as `admin@example.com` / `Admin123!`.

Project structure
- `Controllers/` - MVC controllers
- `Data/` - EF Core DbContext and initializer
- `Models/` - domain models
- `Views/` - Razor views

Notes
- This is a starter implementation for demonstration. For production, harden security, enable HTTPS, configure storage (e.g., cloud blob storage), and add more robust reporting.
