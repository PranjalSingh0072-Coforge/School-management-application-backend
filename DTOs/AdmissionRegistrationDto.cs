using Microsoft.AspNetCore.Http;
using System;
namespace SchoolManagement.API.DTOs
{
public class AdmissionRegistrationDto
{
    public string? Session { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? FatherMobileNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Religion { get; set; }
    public string? AadharNumber { get; set; }
    public string? BloodGroup { get; set; }
    public string? ContactAddress { get; set; }
    public string? PinCode { get; set; }
    public string? Class { get; set; }
    public string? State { get; set; }
    public string? CastCategory { get; set; }
    public string? FeeType { get; set; }
    public decimal RegistrationFee { get; set; }
    public string? PaymentMode { get; set; }

    public required IFormFile Photo { get; set; }
    public required IFormFile TC { get; set; }
    public required IFormFile CharacterCertificate { get; set; }
    public required IFormFile MedicalCertificate { get; set; }
    public required IFormFile CastCertificate { get; set; }
 
    public required IFormFile Domicile { get; set; }
}
}

public interface IFormFile
{
    int Length { get; }
    object FileName { get; }

    Task CopyToAsync(FileStream stream);
}