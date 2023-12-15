using Aggregation.Models;
using Aggregation.Services.Interfaces;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Aggregation.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _client;
        public DoctorService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ResponseEntity<IEnumerable<Doctor>>> GetDoctorsByRole(string role)
        {
            var response = await _client.GetAsync($"/api/doctor/get-by-role?role={Uri.EscapeDataString(role)}");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseEntity<IEnumerable<Doctor>>>(jsonData);
        }
    }
}
