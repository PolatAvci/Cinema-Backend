// --- Dosya: Service/Interfaces/ITheaterService.cs ---
using CinemaProject.Models.TheaterModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Service.Interfaces
{
    public interface ITheaterService
    {
        Task<ResponseTheater?> CreateTheaterAsync(CreateTheaterModel theaterModel);
        Task<IEnumerable<ResponseTheaterSummary>> GetAllTheatersAsync();
        Task<ResponseTheater?> GetTheaterByIdAsync(int id);
        Task<ResponseTheater?> UpdateTheaterAsync(int id, UpdateTheaterModel theaterModel);
        Task<bool> DeleteTheaterAsync(int id);
    }
}