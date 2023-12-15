using Aggregation.Models;
using Aggregation.Services.Interfaces;
using Newtonsoft.Json;

namespace Aggregation.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient _client;
        public PatientService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<ResponseEntity<IEnumerable<Patient>>> GetPatientsByDoctors(IEnumerable<Guid> doctorsId)
        {
            var doctorsIdString = string.Join(",", doctorsId.Select(id => id.ToString()));

            var response = await _client.GetAsync($"/api/patient/get-by-doctors?doctorsId={Uri.EscapeDataString(doctorsIdString)}");
            
            var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseEntity<IEnumerable<Patient>>>(jsonData);
            
        }

    }
}
