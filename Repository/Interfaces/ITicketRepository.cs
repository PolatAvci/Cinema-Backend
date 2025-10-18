using CinemaProject.Entities;

namespace CinemaProject.Repository.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(int id);
        Task AddAsync(Ticket showTime);
        void Delete(Ticket showTime);
        Task SaveChangesAsync();
    }
}