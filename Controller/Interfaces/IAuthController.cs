namespace CinemaProject.Service.Interfaces
{
    public interface IAuthController
    {
        ResponseLogin Login(LoginModel credentials);
    }
}