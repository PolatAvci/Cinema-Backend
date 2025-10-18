using CinemaProject.Entities;

namespace CinemaProject.Repositories.Interfaces
{
    public interface IShowTimeRepository
    {
        Task<IEnumerable<ShowTime>> GetAllAsync();
        Task<ShowTime?> GetByIdAsync(int id);
        Task AddAsync(ShowTime showTime);
        void Delete(ShowTime showTime);
        Task SaveChangesAsync();
    }
}