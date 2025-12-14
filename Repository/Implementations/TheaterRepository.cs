// --- Dosya: Repository/Implementations/TheaterRepository.cs ---
using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Implementations
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly AppDbContext _context;

        public TheaterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Theater theater)
        {
            await _context.Theaters.AddAsync(theater);
        }

        public Task<IEnumerable<Theater>> GetAllAsync()
        {
            var theaters = _context.Theaters.AsEnumerable();
            return Task.FromResult(theaters);
        }

        public Task<Theater?> GetByIdAsync(int id)
        {
            var theater = _context.Theaters.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(theater);
        }
        
        public async Task<Theater?> GetTheaterWithDetailsAsync(int id)
        {
            return await _context.Theaters
                .Include(t => t.Seats)
                .Include(t => t.Cinema)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Delete(Theater theater)
        {
            _context.Theaters.Remove(theater);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}