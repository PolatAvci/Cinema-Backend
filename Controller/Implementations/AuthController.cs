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
        public ResponseLogin Login([FromBody] LoginModel credentials)
        {
            var responseLogin = _authService.LoginAsync(credentials).Result;
            if (responseLogin == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return responseLogin;
        }
    }
}