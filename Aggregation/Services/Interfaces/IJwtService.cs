using Aggregation.Models;

namespace Aggregation.Services.Interfaces
{
    public interface IJwtService
    {
        Task<SignInResponse> SignInAsync(SignInModel model);
        Task<SignInResponse> SignUpAsync(SignUpModel model);
    }
}
