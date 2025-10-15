using CinemaProject.Entities;

namespace CinemaProject.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ResponseUser>> GetAllUsersAsync();
        Task<ResponseUser?> GetUserByIdAsync(int id);
        Task<ResponseUser?> GetUserByEmailAsync(string email);
        Task<ResponseUser> CreateUserAsync(CreateUserModel user);
        Task<ResponseUser?> UpdateUserAsync(int id, UpdateUserModel user);
        Task<bool> DeleteUserAsync(int id);
    }
}
