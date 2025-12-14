// --- Dosya: Controller/Interfaces/ICinemaController.cs ---
using CinemaProject.Entities;
using CinemaProject.Models.CinemaModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Interfaces
{
    public interface ICinemaController
    {
        // CRUD metotlarının tanımları
        Task<ActionResult<ResponseCinema?>> CreateCinema(CreateCinemaModel cinemaModel);
        Task<IEnumerable<ResponseCinemaSummary>> GetAllCinemas();
        Task<ActionResult<ResponseCinema?>> GetCinemaById(int id);
        Task<ActionResult<ResponseCinema?>> UpdateCinema(int id, UpdateCinemaModel cinemaModel);
        Task<IActionResult> DeleteCinema(int id);
    }
}