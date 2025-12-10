namespace CinemaProject.Service.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<ResponseTicket>> GetAllTicketAsync();
        Task<ResponseTicket?> GetTicketByIdAsync(int id);
        Task<ResponseTicket> CreateTicketAsync(CreateTicketModel ticket);
        Task<ResponseTicket?> UpdateTicketAsync(int id, UpdateTicketModel ticket);
        Task<bool> DeleteTicketAsync(int id);
        Task<ResponseTicket?> BuyTicketAsync(int ticketId, BuyTicketModel buyTicketModel);
    }
}