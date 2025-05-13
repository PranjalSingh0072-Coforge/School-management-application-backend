using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagement.API.Repositories;
using SchoolManagement.API.Model;
using SchoolManagement.API.Interfaces;
namespace SchoolManagement.API.Repositories
{
public class AdmissionRepository : IAdmissionRepository
{
    private readonly List<AdmissionRegistration> _registrations = new();

    public Task<IEnumerable<AdmissionRegistration>> GetAllAsync()
    {
        return Task.FromResult(_registrations.AsEnumerable());
    }

    public Task<AdmissionRegistration?> GetByIdAsync(int id)
    {
        var registration = _registrations.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(registration);
    }

    public Task<AdmissionRegistration> AddAsync(AdmissionRegistration registration)
    {
        registration.Id = _registrations.Count + 1;
        _registrations.Add(registration);
        return Task.FromResult(registration);
    }

    public Task<AdmissionRegistration?> UpdateAsync(AdmissionRegistration registration)
    {
        var existing = _registrations.FirstOrDefault(r => r.Id == registration.Id);
        if (existing == null) return Task.FromResult<AdmissionRegistration?>(null);

        _registrations.Remove(existing);
        _registrations.Add(registration);
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        return Task.FromResult(registration);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }

    public Task<bool> DeleteAsync(int id)
    {
        var registration = _registrations.FirstOrDefault(r => r.Id == id);
        if (registration == null) return Task.FromResult(false);

        _registrations.Remove(registration);
        return Task.FromResult(true);
    }
}
}
