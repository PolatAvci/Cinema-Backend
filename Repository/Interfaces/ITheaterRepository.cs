// --- Dosya: Repository/Interfaces/ITheaterRepository.cs ---
using CinemaProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Interfaces
{
    public interface ITheaterRepository
    {
        Task<IEnumerable<Theater>> GetAllAsync();
        Task<Theater?> GetByIdAsync(int id);
        // Seat'leri ve Cinema'yı eager loading ile çeker
        Task<Theater?> GetTheaterWithDetailsAsync(int id); 
        Task AddAsync(Theater theater);
        void Delete(Theater theater);
        Task SaveChangesAsync();
    }
}