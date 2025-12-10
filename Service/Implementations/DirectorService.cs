using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using CinemaProject.Service.Interfaces;

namespace CinemaProject.Service.Implementations
{
    public class DirectorService : IDirectorService
    {
        private readonly IMapper _mapper;
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IMapper mapper, IDirectorRepository directorRepository)
        {
            _mapper = mapper;
            _directorRepository = directorRepository;
        }

        public async Task<ResponseDirector?> CreateDirectorAsync(CreateDirectorModel directorModel)
        {
            var director = _mapper.Map<Director>(directorModel);

            await _directorRepository.AddAsync(director);
            await _directorRepository.SaveChangesAsync();

            return _mapper.Map<ResponseDirector>(director);
        }

        public async Task<IEnumerable<ResponseDirector>> GetAllDirectorsAsync()
        {
            var directors = await _directorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseDirector>>(directors);
        }

        public async Task<ResponseDirector?> GetDirectorByIdAsync(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);
            if (director == null) return null;
            return _mapper.Map<ResponseDirector>(director);
        }

        public async Task<ResponseDirector?> UpdateDirectorAsync(int id, UpdateDirectorModel directorModel)
        {
            var existing = await _directorRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(directorModel, existing);
            await _directorRepository.SaveChangesAsync();

            return _mapper.Map<ResponseDirector>(existing);
        }

        public async Task<bool> DeleteDirectorAsync(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);
            if (director == null) return false;

            _directorRepository.Delete(director);
            await _directorRepository.SaveChangesAsync();
            return true;
        }
    }
}
