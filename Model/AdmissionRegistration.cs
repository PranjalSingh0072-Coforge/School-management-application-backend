namespace SchoolManagement.API.Model
{
public class AdmissionRegistration
{
    public int Id { get; set; }
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

    // This is  for  Files uploads 
    public string? PhotoPath { get; set; }
    public string? TCPath { get; set; }
    public string? CharacterCertificatePath { get; set; }
    public string? MedicalCertificatePath { get; set; }
    public string? CastCertificatePath { get; set; }
    public string? DomicilePath { get; set; }
}
}