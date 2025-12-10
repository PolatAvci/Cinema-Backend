// --- Dosya: Repository/Interfaces/IAddressRepository.cs ---
using CinemaProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address?> GetByIdAsync(int id);
        Task AddAsync(Address address);
        void Delete(Address address);
        Task SaveChangesAsync();
    }
}