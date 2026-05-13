using CertificateVerificationSystemJeyaram.Data;
using CertificateVerificationSystemJeyaram.Models;
using CertificateVerificationSystemJeyaram.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CertificateVerificationSystemJeyaram.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.StudentRecords.Include(s => s.Certificates).ToListAsync();
            var stats = new AdminDashboardViewModel
            {
                TotalStudents = students.Count,
                TotalCertificates = await _context.Certificates.CountAsync(),
                PendingCertificates = await _context.Certificates.CountAsync(c => !c.IsApproved)
            };
            return View(stats);
        }

        public async Task<IActionResult> Students()
        {
            var students = await _context.StudentRecords.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult CreateStudent() => View();

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentRecord model)
        {
            if (!ModelState.IsValid) return View(model);
            model.Created = DateTime.UtcNow;
            _context.StudentRecords.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Students));
        }

        [HttpGet]
        public async Task<IActionResult> UploadCertificate(int id)
        {
            var student = await _context.StudentRecords.FindAsync(id);
            if (student == null) return NotFound();
            return View(new UploadCertificateViewModel { StudentId = id });
        }

        [HttpPost]
        public async Task<IActionResult> UploadCertificate(UploadCertificateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var student = await _context.StudentRecords.FindAsync(model.StudentId);
            if (student == null) return NotFound();

            string uploads = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploads);
            var fileName = Path.GetRandomFileName() + Path.GetExtension(model.File!.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await model.File.CopyToAsync(fs);
            }

            var cert = new Certificate
            {
                StudentRecordId = student.Id,
                Title = model.Title ?? "Certificate",
                IssuedOn = model.IssuedOn,
                CertificateId = Guid.NewGuid().ToString(),
                FilePath = "/uploads/" + fileName,
                IsApproved = false
            };
            _context.Certificates.Add(cert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Students));
        }

        [HttpPost]
        public async Task<IActionResult> ApproveCertificate(int id)
        {
            var cert = await _context.Certificates.FindAsync(id);
            if (cert == null) return NotFound();
            cert.IsApproved = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Students));
        }

        public async Task<IActionResult> Reports()
        {
            var certs = await _context.Certificates.Include(c => c.StudentRecord).ToListAsync();
            return View(certs);
        }
    }
}