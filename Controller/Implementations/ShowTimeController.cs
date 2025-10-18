using CinemaProject.Controller.Interfaces;
using CinemaProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/show-times")]
    public class ShowTimeController : ControllerBase, IShowTimeController
    {
        private IShowTimeService _showTimeService;

        public ShowTimeController(IShowTimeService showTimeService) // Dependency injection
        {
            _showTimeService = showTimeService;
        }

        [HttpPost]
        public async Task<ResponseShowTime?> CreateShowTime([FromBody] CreateShowTimeModel showTimeModel)
        {
            var showTime = await _showTimeService.CreateShowTimeAsync(showTimeModel);
            return showTime;
        }

        [HttpDelete]
        public Task<IActionResult> DeleteShowTime(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IEnumerable<ResponseUser>> GetAllShowTime()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<ResponseUser?> GetShowTimeById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<ResponseUser?> UpdateShowTime(int id, [FromBody] UpdateShowTimeModel showTimeModel)
        {
            throw new NotImplementedException();
        }
    }
}