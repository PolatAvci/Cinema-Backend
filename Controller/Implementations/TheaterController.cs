// --- Dosya: Controller/Implementations/TheaterController.cs ---
using CinemaProject.Controller.Interfaces; // ITheaterController arayüzü için
using CinemaProject.Models.TheaterModels;
using CinemaProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/theaters")]
    [Authorize(Roles = "Admin, Editor")] // Sadece yetkili rollerin CRUD yapabileceği varsayılır
    public class TheaterController : ControllerBase, ITheaterController
    {
        private readonly ITheaterService _theaterService;

        public TheaterController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseTheater?>> CreateTheater([FromBody] CreateTheaterModel theaterModel)
        {
            var theater = await _theaterService.CreateTheaterAsync(theaterModel);
            // Sinema ID geçersizse servis null dönebilir
            if (theater == null) return BadRequest("Salon oluşturulamadı. Sinema ID geçerli olmayabilir.");
            
            // HTTP 201 Created döndürülür
            return CreatedAtAction(nameof(GetTheaterById), new { id = theater.Id }, theater);
        }

        [HttpGet]
        [AllowAnonymous] // Herkes salon listesini görebilir
        public async Task<IEnumerable<ResponseTheaterSummary>> GetAllTheaters()
        {
            return await _theaterService.GetAllTheatersAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseTheater?>> GetTheaterById(int id)
        {
            // Detaylı bilgi (Seats ve Cinema dahil) servis üzerinden çekilir
            var theater = await _theaterService.GetTheaterByIdAsync(id);
            if (theater == null) return NotFound();
            return theater;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseTheater?>> UpdateTheater(int id, [FromBody] UpdateTheaterModel theaterModel)
        {
            var updated = await _theaterService.UpdateTheaterAsync(id, theaterModel);
            if (updated == null) return NotFound("Güncellenecek salon bulunamadı veya Cinema ID geçersiz.");
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheater(int id)
        {
            var deleted = await _theaterService.DeleteTheaterAsync(id);
            if (!deleted) return NotFound();
            return NoContent(); // HTTP 204 No Content
        }
    }
}