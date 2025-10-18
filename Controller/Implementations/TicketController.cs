using CinemaProject.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost]
        public async Task<ResponseTicket?> CreateTicket(CreateTicketModel ticketModel)
        {
            var ticket = await _ticketService.CreateTicketAsync(ticketModel);
            return ticket;
        }

        [HttpDelete("{id}")]
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
        public async Task<ResponseTicket?> UpdateTicket(int id, [FromBody] UpdateTicketModel showTimeModel)
        {
            var updatedTicket = await _ticketService.UpdateTicketAsync(id, showTimeModel);
            return updatedTicket;
        }
    }
}