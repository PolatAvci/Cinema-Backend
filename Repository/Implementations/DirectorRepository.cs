using AutoMapper;
using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;

namespace CinemaProject.Repository.Implementations
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly AppDbContext _context;

        public DirectorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Director director)
        {
            await _context.Directors.AddAsync(director);
        }

        public Task<IEnumerable<Director>> GetAllAsync()
        {
            var directors = _context.Directors.AsEnumerable();
            return Task.FromResult(directors);
        }

        public Task<Director?> GetByIdAsync(int id)
        {
            var director = _context.Directors.FirstOrDefault(d => d.Id == id);
            return Task.FromResult(director);
        }

        public void Delete(Director director)
        {
            _context.Directors.Remove(director);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
