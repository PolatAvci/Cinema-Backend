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
        public async Task<IActionResult> DeleteShowTime(int id)
        {
            var deleted = await _showTimeService.DeleteShowTimeAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseShowTime>> GetAllShowTime()
        {
            var showTimes = await _showTimeService.GetAllShowTimeAsync();
            return showTimes;
        }

        [HttpGet("{id}")]
        public async Task<ResponseShowTime?> GetShowTimeById(int id)
        {
            var showTime = await _showTimeService.GetShowTimeByIdAsync(id);
            return showTime;
        }

        [HttpPut("{id}")]
        public async Task<ResponseShowTime?> UpdateShowTime(int id, [FromBody] UpdateShowTimeModel showTimeModel)
        {
            var updatedShowTime = await _showTimeService.UpdateShowTimeAsync(id, showTimeModel);
            return updatedShowTime;
        }
    }
}