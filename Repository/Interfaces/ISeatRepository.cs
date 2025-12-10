using CinemaProject.Entities;

namespace CinemaProject.Repository.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllAsync();
        Task<Seat?> GetByIdAsync(int id);
        Task<Seat?> GetByIdWithDetailsAsync(int id);
        Task AddAsync(Seat seat);
        void Delete(Seat seat);
        Task SaveChangesAsync();
    }
}