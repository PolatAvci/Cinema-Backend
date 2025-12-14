
using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Implementations
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly AppDbContext _context;

        public CinemaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
        }

        public Task<IEnumerable<Cinema>> GetAllAsync()
        {
            
            var cinemas = _context.Cinemas.AsEnumerable();
            return Task.FromResult(cinemas);
        }

        public Task<Cinema?> GetByIdAsync(int id)
        {
           
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(cinema);
        }

        
        public async Task<Cinema?> GetCinemaWithDetailsAsync(int id)
        {
            
            var cinema = await _context.Cinemas
                .Include(c => c.Address)
                .Include(c => c.Theaters)
                .FirstOrDefaultAsync(c => c.Id == id);
            return cinema;
        }

        public void Delete(Cinema cinema)
        {
            _context.Cinemas.Remove(cinema);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}