using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CertificateVerificationSystemJayaram.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CertificateVerificationSystemJayaram.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider services, IConfiguration configuration)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var context = services.GetRequiredService<ApplicationDbContext>();

            // Ensure database created
            await context.Database.EnsureCreatedAsync();

            string[] roles = new[] { "Admin", "Student", "Employer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            var adminEmail = configuration["AdminUser:Email"] ?? "admin@example.com";
            var adminPassword = configuration["AdminUser:Password"] ?? "Admin123!";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, FullName = "System Admin" };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Add sample student
            if (!context.StudentRecords.Any())
            {
                var student = new StudentRecord
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "student@example.com",
                    EnrollmentNumber = "ENR001",
                    Program = "BSc Computer Science",
                    Created = DateTime.UtcNow
                };
                context.StudentRecords.Add(student);
                await context.SaveChangesAsync();

                var cert = new Certificate
                {
                    StudentRecordId = student.Id,
                    Title = "Bachelor Degree",
                    IssuedOn = DateTime.UtcNow,
                    CertificateId = Guid.NewGuid().ToString(),
                    FilePath = "",
                    IsApproved = true
                };
                context.Certificates.Add(cert);
                await context.SaveChangesAsync();
            }
        }
    }
}