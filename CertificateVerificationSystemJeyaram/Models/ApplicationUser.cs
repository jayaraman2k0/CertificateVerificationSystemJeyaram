using Microsoft.AspNetCore.Identity;

namespace CertificateVerificationSystemJeyaram.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}