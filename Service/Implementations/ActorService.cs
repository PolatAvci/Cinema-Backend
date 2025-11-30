using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using CinemaProject.Service.Interfaces;

namespace CinemaProject.Service.Implementations
{
    public class ActorService : IActorService
    {
        private readonly IMapper _mapper;
        private readonly IActorRepository _actorRepository;

        public ActorService(IMapper mapper, IActorRepository actorRepository)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
        }

        public async Task<ResponseActor?> CreateActorAsync(CreateActorModel actorModel)
        {
            var actor = _mapper.Map<Actor>(actorModel);

            await _actorRepository.AddAsync(actor);
            await _actorRepository.SaveChangesAsync();

            return _mapper.Map<ResponseActor>(actor);
        }

        public async Task<IEnumerable<ResponseActor>> GetAllActorsAsync()
        {
            var actors = await _actorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseActor>>(actors);
        }

        public async Task<ResponseActor?> GetActorByIdAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            if (actor == null) return null;
            return _mapper.Map<ResponseActor>(actor);
        }

        public async Task<ResponseActor?> UpdateActorAsync(int id, UpdateActorModel actorModel)
        {
            var existing = await _actorRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(actorModel, existing);
            await _actorRepository.SaveChangesAsync();

            return _mapper.Map<ResponseActor>(existing);
        }

        public async Task<bool> DeleteActorAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            if (actor == null) return false;

            _actorRepository.Delete(actor);
            await _actorRepository.SaveChangesAsync();
            return true;
        }
    }
}
