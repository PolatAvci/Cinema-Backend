using CinemaProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/actors")]
    [Authorize(Roles = "Admin")]
    public class ActorController : ControllerBase, IActorController
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpPost]
        public async Task<ResponseActor?> CreateActor([FromBody] CreateActorModel actorModel)
        {
            var actor = await _actorService.CreateActorAsync(actorModel);
            return actor;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseActor>> GetAllActors()
        {
            var actors = await _actorService.GetAllActorsAsync();
            return actors;
        }

        [HttpGet("{id}")]
        public async Task<ResponseActor?> GetActorById(int id)
        {
            var actor = await _actorService.GetActorByIdAsync(id);
            return actor;
        }

        [HttpPut("{id}")]
        public async Task<ResponseActor?> UpdateActor(int id, [FromBody] UpdateActorModel actorModel)
        {
            var updated = await _actorService.UpdateActorAsync(id, actorModel);
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var deleted = await _actorService.DeleteActorAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
