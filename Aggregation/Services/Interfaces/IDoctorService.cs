using Aggregation.Models;

namespace Aggregation.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<ResponseEntity<IEnumerable<Doctor>>> GetDoctorsByRole(string role);
    }
}
