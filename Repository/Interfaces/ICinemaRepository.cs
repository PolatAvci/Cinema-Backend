// --- Dosya: Repository/Interfaces/ICinemaRepository.cs ---
using CinemaProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Repository.Interfaces
{
    public interface ICinemaRepository
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema?> GetByIdAsync(int id);
        
        // Address ve Theaters gibi detayları yükler
        Task<Cinema?> GetCinemaWithDetailsAsync(int id); 
        
        Task AddAsync(Cinema cinema);
        void Delete(Cinema cinema);
        Task SaveChangesAsync();
    }
}