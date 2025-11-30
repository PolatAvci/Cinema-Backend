using CinemaProject.Entities;

namespace CinemaProject.Repository.Interfaces
{
    public interface IDirectorRepository
    {
        Task AddAsync(Director director);
        Task<IEnumerable<Director>> GetAllAsync();
        Task<Director?> GetByIdAsync(int id);
        void Delete(Director director);
        Task SaveChangesAsync();
    }
}
