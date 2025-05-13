using System.Collections.Generic;
using System.Threading.Tasks;

using SchoolManagement.API.Model;

namespace SchoolManagement.API.Interfaces{
public interface IAdmissionRepository
{
    Task<IEnumerable<AdmissionRegistration>> GetAllAsync();
    Task<AdmissionRegistration?> GetByIdAsync(int id);
    Task<AdmissionRegistration> AddAsync(AdmissionRegistration registration);
    Task<AdmissionRegistration?> UpdateAsync(AdmissionRegistration registration);
    Task<bool> DeleteAsync(int id);
}
}





