using Controller.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace Controller.Implementations
{
    [ApiController]
    [Route("api/seats")]
    public class SeatController : ControllerBase, ISeatController
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpPost]
        public async Task<ResponseSeat?> CreateSeat(CreateSeatModel seatModel)
        {
            var seat = await _seatService.CreateSeatAsync(seatModel);
            return seat;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var deleted = await _seatService.DeleteSeatAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public Task<IEnumerable<ResponseSeat>> GetAllSeat()
        {
            var seats = _seatService.GetAllSeatAsync();
            return seats;
        }

        [HttpGet("{id}")]
        public Task<ResponseSeat?> GetSeatById(int id)
        {
            var seat = _seatService.GetSeatByIdAsync(id);
            return seat;
        }

        [HttpPut("{id}")]
        public Task<ResponseSeat?> UpdateSeat(int id, UpdateSeatModel seatModel)
        {
            var seat = _seatService.UpdateSeatAsync(id, seatModel);
            return seat;
        }
    }
}