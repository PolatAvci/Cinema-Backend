using CinemaProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/directors")]
    [Authorize(Roles = "Admin")]
    public class DirectorController : ControllerBase, IDirectorController
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpPost]
        public async Task<ResponseDirector?> CreateDirector([FromBody] CreateDirectorModel directorModel)
        {
            var director = await _directorService.CreateDirectorAsync(directorModel);
            return director;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseDirector>> GetAllDirectors()
        {
            var directors = await _directorService.GetAllDirectorsAsync();
            return directors;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDirector?> GetDirectorById(int id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            return director;
        }

        [HttpPut("{id}")]
        public async Task<ResponseDirector?> UpdateDirector(int id, [FromBody] UpdateDirectorModel directorModel)
        {
            var updated = await _directorService.UpdateDirectorAsync(id, directorModel);
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var deleted = await _directorService.DeleteDirectorAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
