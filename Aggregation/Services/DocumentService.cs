using Aggregation.Models;
using Aggregation.Services.Interfaces;
using Newtonsoft.Json;
using System.Data;

namespace Aggregation.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly HttpClient _client;
        public DocumentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<ResponseEntity<Document>> GetDocumentByEmail(string email)
        {
            var response = await _client.GetAsync($"/api/document/get-by-email?email={Uri.EscapeDataString(email)}");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseEntity<Document>>(jsonData);
        }
    }
}
