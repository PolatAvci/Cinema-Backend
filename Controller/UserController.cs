using CinemaProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public async Task<ResponseUser?> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user;
        }
    }
}