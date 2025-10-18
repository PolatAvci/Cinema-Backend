using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Service.Interfaces
{
    public interface ITicketController
    {
        public Task<ResponseTicket?> CreateTicket(CreateTicketModel ticketModel);

        public Task<IEnumerable<ResponseTicket>> GetAllTicket();

        public Task<ResponseTicket?> GetTicketById(int id);

        public Task<IActionResult> DeleteTicket(int id);

        public Task<ResponseTicket?> UpdateTicket(int id, UpdateTicketModel ticketModel);
    }
}