
using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
        }

        public Task<IEnumerable<Address>> GetAllAsync()
        {
            
            var addresses = _context.Addresses.AsEnumerable();
            return Task.FromResult(addresses);
        }

        public Task<Address?> GetByIdAsync(int id)
        {
            
            var address = _context.Addresses.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(address);
        }

        public void Delete(Address address)
        {
            _context.Addresses.Remove(address);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}