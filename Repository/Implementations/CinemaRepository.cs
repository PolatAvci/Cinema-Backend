// --- Dosya: Repository/Implementations/CinemaRepository.cs ---
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
// using CinemaProject.Data.Context; 

namespace CinemaProject.Repository.Implementations
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationDbContext _context;

        public CinemaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task<Cinema?> GetByIdAsync(int id)
        {
            return await _context.Cinemas.FindAsync(id);
        }
        
        public async Task<Cinema?> GetCinemaWithDetailsAsync(int id)
        {
            // İlişkili varlıkları Include ile çekiyoruz
            return await _context.Cinemas
                .Include(c => c.Address)
                .Include(c => c.Theaters)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
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