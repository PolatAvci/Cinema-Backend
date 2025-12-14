// --- Dosya: Controller/Implementations/CinemaController.cs ---
using CinemaProject.Controller.Interfaces;
using CinemaProject.Entities;
using CinemaProject.Models.CinemaModels;
using CinemaProject.Service.Interfaces; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/cinemas")]
    [Authorize(Roles = "Admin")] 
    public class CinemaController : ControllerBase, ICinemaController
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseCinema?>> CreateCinema([FromBody] CreateCinemaModel cinemaModel)
        {
            
            var cinema = await _cinemaService.CreateCinemaAsync(cinemaModel);
            
            
            if (cinema == null) return BadRequest("Sinema oluşturulamadı. Adres ID geçerli olmayabilir.");
            
           
            return CreatedAtAction(nameof(GetCinemaById), new { id = cinema.Id }, cinema); 
        }

        [HttpGet]
        [AllowAnonymous] 
        public async Task<IEnumerable<ResponseCinemaSummary>> GetAllCinemas()
        {
            return await _cinemaService.GetAllCinemasAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseCinema?>> GetCinemaById(int id)
        {
            var cinema = await _cinemaService.GetCinemaByIdAsync(id);
            if (cinema == null) return NotFound();
            return cinema;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseCinema?>> UpdateCinema(int id, [FromBody] UpdateCinemaModel cinemaModel)
        {
            var updated = await _cinemaService.UpdateCinemaAsync(id, cinemaModel);
            
            if (updated == null) return NotFound("Güncellenecek sinema bulunamadı veya sağlanan adres ID geçersiz.");
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(int id)
        {
            var deleted = await _cinemaService.DeleteCinemaAsync(id);
            
            if (!deleted) return NotFound(); 
            
            return NoContent(); 
        }
    }
}