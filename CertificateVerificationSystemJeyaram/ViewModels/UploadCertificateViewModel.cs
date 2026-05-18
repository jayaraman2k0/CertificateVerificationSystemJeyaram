using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CertificateVerificationSystemJeyaram.ViewModels
{
    public class UploadCertificateViewModel
    {
        public int StudentId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime IssuedOn { get; set; }

        [Required]
        public IFormFile? File { get; set; }
    }
}