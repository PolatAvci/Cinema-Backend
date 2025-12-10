using System.Threading.Tasks;
using CinemaProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : IAuthController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ResponseLogin> Login([FromBody] LoginModel credentials)
        {
            var responseLogin = await _authService.LoginAsync(credentials);
            if (responseLogin == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return responseLogin;
        }

        [HttpPost("refresh")]
        public async Task<ResponseRefresh> Refresh([FromBody] TokenRequest tokenRequest)
        {
            var response = await _authService.Refresh(tokenRequest);
            return response;
        }
    }
}