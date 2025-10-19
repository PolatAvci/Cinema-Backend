using System.Threading.Tasks;
using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Implementations
{
    public class SeatRepository : ISeatRepository
    {
        private readonly AppDbContext _context;

        public SeatRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Seat seat)
        {
            await _context.Seats.AddAsync(seat);
        }

        public void Delete(Seat seat)
        {
            _context.Seats.Remove(seat);
        }

        public async Task<IEnumerable<Seat>> GetAllAsync()
        {
            var seats = await _context.Seats
                                .Include(s => s.Theater)
                                .ToListAsync();
            return seats;
        }

        public async Task<Seat?> GetByIdAsync(int id)
        {
            var seat = await _context.Seats
                                        .Include(s => s.Theater)
                                        .FirstOrDefaultAsync(s => s.Id == id);
            return seat;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}