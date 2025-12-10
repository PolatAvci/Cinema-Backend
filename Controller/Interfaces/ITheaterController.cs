// --- Dosya: Controller/Interfaces/ITheaterController.cs ---
using CinemaProject.Models.TheaterModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Interfaces
{
    public interface ITheaterController
    {
        Task<ActionResult<ResponseTheater?>> CreateTheater(CreateTheaterModel theaterModel);
        Task<IEnumerable<ResponseTheaterSummary>> GetAllTheaters();
        Task<ActionResult<ResponseTheater?>> GetTheaterById(int id);
        Task<ActionResult<ResponseTheater?>> UpdateTheater(int id, UpdateTheaterModel theaterModel);
        Task<IActionResult> DeleteTheater(int id);
    }
}