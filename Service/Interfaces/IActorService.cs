namespace CinemaProject.Service.Interfaces
{
    public interface IActorService
    {
        Task<ResponseActor?> CreateActorAsync(CreateActorModel actorModel);
        Task<IEnumerable<ResponseActor>> GetAllActorsAsync();
        Task<ResponseActor?> GetActorByIdAsync(int id);
        Task<ResponseActor?> UpdateActorAsync(int id, UpdateActorModel actorModel);
        Task<bool> DeleteActorAsync(int id);
    }
}
