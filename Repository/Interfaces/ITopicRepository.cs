using CinemaProject.Entities;

namespace CinemaProject.Repository.Interfaces
{
    public interface ITopicRepository
    {
        Task AddAsync(Topic topic);
        Task<IEnumerable<Topic>> GetAllAsync();
        Task<Topic?> GetByIdAsync(int id);
        void Delete(Topic topic);
        Task SaveChangesAsync();
    }
}