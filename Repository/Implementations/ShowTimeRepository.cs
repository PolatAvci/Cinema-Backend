using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Repositories.Implementations
{
    public class ShowTimeRepository : IShowTimeRepository
    {
        private AppDbContext _context;

        public ShowTimeRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(ShowTime showTime)
        {
            await _context.AddAsync(showTime);
        }

        public void Delete(ShowTime showTime)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowTime>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ShowTime?> GetByIdAsync(int id)
        {
            var showTime = await _context.ShowTimes
                                .Include(s => s.Movie)
                                .Include(s => s.Theater)
                                .FirstOrDefaultAsync(s => s.Id == id);
            return showTime;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(ShowTime showTime)
        {
            throw new NotImplementedException();
        }
    }
}