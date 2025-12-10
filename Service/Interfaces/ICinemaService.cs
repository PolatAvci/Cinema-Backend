// --- Dosya: Service/Interfaces/ICinemaService.cs ---
using CinemaProject.Models.CinemaModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Service.Interfaces
{
    public interface ICinemaService
    {
        Task<ResponseCinema?> CreateCinemaAsync(CreateCinemaModel cinemaModel);
        Task<IEnumerable<ResponseCinemaSummary>> GetAllCinemasAsync();
        Task<ResponseCinema?> GetCinemaByIdAsync(int id);
        Task<ResponseCinema?> UpdateCinemaAsync(int id, UpdateCinemaModel cinemaModel);
        Task<bool> DeleteCinemaAsync(int id);
    }
}