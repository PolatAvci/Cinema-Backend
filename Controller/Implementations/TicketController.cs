using CinemaProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketController : ControllerBase, ITicketController
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPatch("{id}/buy")]
        [Authorize]
        public Task<ResponseTicket?> BuyTicket(int id)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userRoleClaim = User.FindFirst(System.Security.Claims.ClaimTypes.Role);
            if (userIdClaim == null || userRoleClaim == null)
                throw new UnauthorizedAccessException("User ID claim not found.");

            int userId = int.Parse(userIdClaim.Value);
            if (!Enum.TryParse<Role>(userRoleClaim.Value, out var userRole))
                throw new UnauthorizedAccessException("Invalid role in token.");

            var buyTicketModel = new BuyTicketModel
            {
                UserId = userId,
                Role = userRole,
            };

            var ticket = _ticketService.BuyTicketAsync(id, buyTicketModel);
            return ticket;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseTicket?> CreateTicket([FromBody] CreateTicketModel ticketModel)
        {
            var ticket = await _ticketService.CreateTicketAsync(ticketModel);
            return ticket;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var deleted = await _ticketService.DeleteTicketAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseTicket>> GetAllTicket()
        {
            var tickets = await _ticketService.GetAllTicketAsync();
            return tickets;
        }

        [HttpGet("{id}")]
        public async Task<ResponseTicket?> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            return ticket;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseTicket?> UpdateTicket(int id, [FromBody] UpdateTicketModel showTimeModel)
        {
            var updatedTicket = await _ticketService.UpdateTicketAsync(id, showTimeModel);
            return updatedTicket;
        }
    }
}