using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Interfaces
{
    public interface IUserController
    {
        public Task<IActionResult> CreateUser(CreateUserModel userModel);

        public Task<IEnumerable<ResponseUser>> GetAllUser();

        public Task<ResponseUser?> GetUserById(int id);

        public Task<IActionResult> DeleteUser(int id);

        public Task<ResponseUser?> UpdateUser(int id, UpdateUserModel user);
    }
}