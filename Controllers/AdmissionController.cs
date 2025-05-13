using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;
using SchoolManagement.API.Model;
using SchoolManagement.API.Repositories;
using SchoolManagement.API.Interfaces;
using SchoolManagement.API.DTOs;


namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionRepository _repository;

        public AdmissionController(IAdmissionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var registrations = await _repository.GetAllAsync();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registration = await _repository.GetByIdAsync(id);
            if (registration == null) return NotFound();
            return Ok(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AdmissionRegistrationDto dto)
        {
            var registration = new AdmissionRegistration
            {
                Session = dto.Session,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                Email = dto.Email,
                RegistrationNumber = dto.RegistrationNumber,
                FatherMobileNumber = dto.FatherMobileNumber,
                DateOfBirth = dto.DateOfBirth,
                Religion = dto.Religion,
                AadharNumber = dto.AadharNumber,
                BloodGroup = dto.BloodGroup,
                ContactAddress = dto.ContactAddress,
                PinCode = dto.PinCode,
                Class = dto.Class,
                State = dto.State,
                CastCategory = dto.CastCategory,
                FeeType = dto.FeeType,
                RegistrationFee = dto.RegistrationFee,
                PaymentMode = dto.PaymentMode,
                PhotoPath = await SaveFile(dto.Photo, "photos"),
                TCPath = await SaveFile(dto.TC, "documents"),
                CharacterCertificatePath = await SaveFile(dto.CharacterCertificate, "documents"),
                MedicalCertificatePath = await SaveFile(dto.MedicalCertificate, "documents"),
                CastCertificatePath = await SaveFile(dto.CastCertificate, "documents"),
                DomicilePath = await SaveFile(dto.Domicile, "documents")
            };

            var created = await _repository.AddAsync(registration);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AdmissionRegistration updated)
        {
            updated.Id = id;
            var result = await _repository.UpdateAsync(updated);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/pdf")]
        public IActionResult DownloadPdf(int id)
        {
            // Placeholder for PDF generation
            return Ok($"PDF for registration ID {id} would be generated here.");
        }

        private async Task<string?> SaveFile(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0) return null;

            var uploads = Path.Combine("Uploads", folder);
            Directory.CreateDirectory(uploads);

            var filePath = Path.Combine(uploads, $"{Guid.NewGuid()}_{file.FileName}");
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return filePath;
        }
    }
}
