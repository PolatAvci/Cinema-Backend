using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Service.Interfaces
{
    public interface IActorController
    {
        Task<ResponseActor?> CreateActor(CreateActorModel actorModel);

        Task<IEnumerable<ResponseActor>> GetAllActors();

        Task<ResponseActor?> GetActorById(int id);

        Task<IActionResult> DeleteActor(int id);

        Task<ResponseActor?> UpdateActor(int id, UpdateActorModel actorModel);
    }
}
