using System.Security.Claims;
using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repositories.Interfaces;
using CinemaProject.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CinemaProject.Services.Implementations
{
    public class UserService : IUserService
    {
        IMapper _mapper;
        IUserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<ResponseUser> CreateUserAsync(CreateUserModel user)
        {
            // TODO: Token veri tabanına eklenebilir
            var newUser = _mapper.Map<User>(user);

            newUser.Password = _passwordHasher.HashPassword(newUser, user.Password);

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();
            var responseUser = _mapper.Map<ResponseUser>(newUser);
            return responseUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            _userRepository.Delete(user);

            await _userRepository.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<ResponseUser>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var responseUsers = _mapper.Map<IEnumerable<ResponseUser>>(users);

            return responseUsers;
        }

        public async Task<ResponseUser?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            var responseUser = _mapper.Map<ResponseUser>(user);
            return responseUser;
        }

        public async Task<ResponseUser?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var responseUser = _mapper.Map<ResponseUser>(user);
            return responseUser;

        }

        public async Task<ResponseUser?> GetMyProfileAsync(ClaimsPrincipal user)
        {

            var userId = GetUserIdFromClaims(user);

            var dbUser = await _userRepository.GetByIdAsync(userId);
            if (dbUser == null)
                throw new Exception("User not found.");

            var response = _mapper.Map<ResponseUser>(dbUser);

            return response;
        }


        public async Task<ResponseUser?> UpdateUserAsync(int id, UpdateUserModel user)
        {
            var oldUser = await _userRepository.GetByIdAsync(id);

            if (oldUser == null) return null;

            oldUser.Name = user.Name;
            oldUser.Email = user.Email;
            oldUser.BirthDate = user.BirthDate;

            _userRepository.Update(oldUser);

            await _userRepository.SaveChangesAsync();

            var responseUser = _mapper.Map<ResponseUser>(oldUser);

            return responseUser;
        }

        public async Task<ResponseUser?> UpdateMyProfileAsync(ClaimsPrincipal user, UpdateUserModel userModel)
        {
            var id = GetUserIdFromClaims(user);
            var updatedUser = await UpdateUserAsync(id, userModel);
            return updatedUser;
        }

        private int GetUserIdFromClaims(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User ID not found in token.");

            int userId = int.Parse(userIdClaim.Value);

            return userId;
        }
    }
}