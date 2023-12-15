using Aggregation.Models;

namespace Aggregation.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ResponseEntity<IEnumerable<Patient>>> GetPatientsByDoctors(IEnumerable<Guid> doctorsId);
    }
}
