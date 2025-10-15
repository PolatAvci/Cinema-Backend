using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repositories.Interfaces;
using CinemaProject.Services.Interfaces;

namespace CinemaProject.Services.Implementations
{
    public class UserService : IUserService
    {
        IMapper _mapper;
        IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResponseUser> CreateUserAsync(CreateUserModel user)
        {
            var newUser = _mapper.Map<User>(user);
            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();
            var responseUser = _mapper.Map<ResponseUser>(newUser);
            return responseUser;
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResponseUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseUser?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseUser?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var responseUser = _mapper.Map<ResponseUser>(user);
            return responseUser;

        }

        public Task<ResponseUser?> UpdateUserAsync(int id, UpdateUserModel user)
        {
            throw new NotImplementedException();
        }
    }
}