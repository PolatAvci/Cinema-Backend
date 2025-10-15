using CinemaProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel userModel)
        {
            var user = await _userService.CreateUserAsync(userModel);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseUser>> GetAllUser()
        {
            var users = await _userService.GetAllUsersAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ResponseUser?> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            bool deleted = await _userService.DeleteUserAsync(id);

            if (!deleted)
                return NotFound(); // 404

            return NoContent(); // 204
        }

        [HttpPut("{id}")]
        public async Task<ResponseUser?> UpdateUser(int id, [FromBody] UpdateUserModel user)
        {
            return await _userService.UpdateUserAsync(id, user);
        }
    }
}