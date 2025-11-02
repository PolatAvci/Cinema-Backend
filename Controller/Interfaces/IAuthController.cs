namespace CinemaProject.Service.Interfaces
{
    public interface IAuthController
    {
        Task<ResponseLogin> Login(LoginModel credentials);

        Task<ResponseRefresh> Refresh(TokenRequest tokenRequest);
    }
}