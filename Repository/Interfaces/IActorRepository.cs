using CinemaProject.Entities;

namespace CinemaProject.Repository.Interfaces
{
    public interface IActorRepository
    {
        Task AddAsync(Actor actor);
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor?> GetByIdAsync(int id);
        void Delete(Actor actor);
        Task SaveChangesAsync();
    }
}
