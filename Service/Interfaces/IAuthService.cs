using CinemaProject.Entities;

namespace CinemaProject.Service.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);

        Task<ResponseLogin?> LoginAsync(LoginModel credentials);
    }
}