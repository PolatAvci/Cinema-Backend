using CinemaProject.Entities;

namespace CinemaProject.Service.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);

        string GenerateRefreshToken();

        Task<ResponseRefresh> Refresh(TokenRequest TokenRequest);

        Task<ResponseLogin?> LoginAsync(LoginModel credentials);
    }
}