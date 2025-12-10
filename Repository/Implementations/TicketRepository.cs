using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Repository.Implementations
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ticket showTime)
        {
            await _context.Tickets.AddAsync(showTime);
        }

        public void Delete(Ticket showTime)
        {
            _context.Tickets.Remove(showTime);
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            var tickets = await _context.Tickets
                                            .Include(t => t.ShowTime)
                                            .Include(t => t.User)
                                            .Include(t => t.Seat)
                                            .Include(t => t.ShowTime)
                                            .Include(t => t.Cinema)
                                            .ToListAsync();
            return tickets;
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            var ticket = await _context.Tickets
                                            .Include(t => t.ShowTime)
                                            .Include(t => t.User)
                                            .Include(t => t.Seat)
                                            .Include(t => t.ShowTime)
                                            .Include(t => t.Cinema)
                                            .FirstOrDefaultAsync(t => t.Id == id);
            return ticket;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}