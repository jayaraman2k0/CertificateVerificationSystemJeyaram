using CertificateVerificationSystemJeyaram.Data;
using CertificateVerificationSystemJeyaram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CertificateVerificationSystemJeyaram.Controllers
{
    public class VerificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VerificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Verify(string? certificateId)
        {
            if (string.IsNullOrEmpty(certificateId)) return View("Index");

            var cert = await _context.Certificates.Include(c => c.StudentRecord)
                .FirstOrDefaultAsync(c => c.CertificateId == certificateId);

            var log = new VerificationLog
            {
                CertificateId = certificateId,
                CheckedOn = DateTime.UtcNow,
                CheckedByIp = HttpContext.Connection.RemoteIpAddress?.ToString(),
                IsValid = cert != null && cert.IsApproved
            };
            _context.VerificationLogs.Add(log);
            await _context.SaveChangesAsync();

            if (cert == null)
                return View("NotFound");

            return View("Result", cert);
        }
    }
}