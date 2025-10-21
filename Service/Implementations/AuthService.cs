using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repositories.Interfaces;
using CinemaProject.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CinemaProject.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        private readonly IMapper _mapper;

        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(IConfiguration config, IUserRepository userRepository, IMapper mapper)
        {
            _config = config;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<User>();
        }
        
        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _config.GetSection("Jwt");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ResponseLogin?> LoginAsync(LoginModel credentials)
        {
            var user = await _userRepository.GetByEmailAsync(credentials.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, credentials.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var responseUser = _mapper.Map<ResponseUser>(user);

            var responseLogin = new ResponseLogin
            {
                User = responseUser,
                Token = GenerateJwtToken(user)
            };

            return responseLogin;
        }
    }
}