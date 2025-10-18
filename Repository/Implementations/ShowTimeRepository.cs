using System.Threading.Tasks;
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
             _context.Remove(showTime);
        }

        public Task<IEnumerable<ShowTime>> GetAllAsync()
        {
            var showTimes = _context.ShowTimes
                                .Include(s => s.Movie)
                                .Include(s => s.Theater)
                                .AsEnumerable();
            return Task.FromResult(showTimes);
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