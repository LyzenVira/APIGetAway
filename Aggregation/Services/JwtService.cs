using Aggregation.Models;
using Aggregation.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Aggregation.Services
{
    public class JwtService : IJwtService
    {
        private readonly HttpClient _client;
        public JwtService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<SignInResponse> SignInAsync(SignInModel model)
        {
            var jsonModel = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/auth/sign-in", content);
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SignInResponse>(jsonData);
        }

        public async Task<SignInResponse> SignUpAsync(SignUpModel model)
        {
            var jsonModel = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/auth/sign-up", content);
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SignInResponse>(jsonData);
        }
    }
}