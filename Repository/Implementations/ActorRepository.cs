using AutoMapper;
using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;

namespace CinemaProject.Repository.Implementations
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;

        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
        }

        public Task<IEnumerable<Actor>> GetAllAsync()
        {
            var actors = _context.Actors.AsEnumerable();
            return Task.FromResult(actors);
        }

        public Task<Actor?> GetByIdAsync(int id)
        {
            var actor = _context.Actors.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(actor);
        }

        public void Delete(Actor actor)
        {
            _context.Actors.Remove(actor);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
