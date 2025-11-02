using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
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

            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireDate = DateTime.Now.AddDays(7); // RefreshToken 7 gün geçerli
            await _userRepository.SaveChangesAsync();

            var responseUser = _mapper.Map<ResponseUser>(user);

            var responseLogin = new ResponseLogin
            {
                User = responseUser,
                AccessToken = GenerateJwtToken(user),
                RefreshToken = refreshToken
            };

            return responseLogin;
        }

        public async Task<ResponseRefresh> Refresh(TokenRequest tokenRequest)
        {
            if (tokenRequest == null || string.IsNullOrEmpty(tokenRequest.RefreshToken))
                throw new ArgumentException("Invalid client request");

            // Token'dan kullanıcı ID'sini çıkar
            var principal = GetPrincipalFromExpiredToken(tokenRequest.AccessToken);
            if (principal == null)
                throw new SecurityTokenException("Invalid access token");

            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                throw new SecurityTokenException("User ID not found in token");

            if (!int.TryParse(userIdClaim, out int userId))
                throw new SecurityTokenException("Invalid user ID format");

            // Kullanıcıyı ID ile bul
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            if (user.RefreshToken != tokenRequest.RefreshToken)
                throw new SecurityTokenException("Refresh token does not match");

            if (user.RefreshTokenExpireDate <= DateTime.UtcNow)
                throw new SecurityTokenException("Refresh token has expired");

            // Yeni token üret
            var newAccessToken = GenerateJwtToken(user);
            var newRefreshToken = GenerateRefreshToken();

            // Refresh token’ı güncelle
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpireDate = DateTime.UtcNow.AddDays(7);
            await _userRepository.SaveChangesAsync();

            var responseUser = _mapper.Map<ResponseUser>(user);

            return new ResponseRefresh
            {
                User = responseUser,
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            };
        }



        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _config.GetSection("Jwt");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!)),
                ValidateLifetime = false // expired olsa bile çözümlenecek
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtToken ||
                !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

    }
}