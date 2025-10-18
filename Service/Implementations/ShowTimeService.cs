using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repositories.Interfaces;
using CinemaProject.Services.Interfaces;

namespace CinemaProject.Services.Implementations
{
    public class ShowTimeService : IShowTimeService
    {
        private IShowTimeRepository _showTimeRepository;

        private IMapper _mapper;

        public ShowTimeService(IShowTimeRepository showTimeRepository, IMapper mapper)
        {
            _showTimeRepository = showTimeRepository;

            _mapper = mapper;
        }
        
        public async Task<ResponseShowTime> CreateShowTimeAsync(CreateShowTimeModel showtime)
        {
            var newShowTime = _mapper.Map<ShowTime>(showtime);
            await _showTimeRepository.AddAsync(newShowTime);
            await _showTimeRepository.SaveChangesAsync();

            var fullShowTime = await _showTimeRepository.GetByIdAsync(newShowTime.Id); // Movie ve Theater dahil

            var responseShowTime = _mapper.Map<ResponseShowTime>(fullShowTime);
            return responseShowTime;
        }

        public Task<bool> DeleteShowTimeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResponseShowTime>> GetAllShowTimeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseShowTime?> GetShowTimeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseShowTime?> UpdateShowTimeAsync(int id, UpdateShowTimeModel user)
        {
            throw new NotImplementedException();
        }

    }
}