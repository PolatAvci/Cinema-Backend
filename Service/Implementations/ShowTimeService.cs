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

        public async Task<bool> DeleteShowTimeAsync(int id)
        {
            var showTime =  await _showTimeRepository.GetByIdAsync(id);
            if (showTime == null) return false;

            _showTimeRepository.Delete(showTime);
            await _showTimeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ResponseShowTime>> GetAllShowTimeAsync()
        {
            var showTimes = await _showTimeRepository.GetAllAsync();
            var responseShowTimes = _mapper.Map<IEnumerable<ResponseShowTime>>(showTimes);

            return responseShowTimes;
        }

        public async Task<ResponseShowTime?> GetShowTimeByIdAsync(int id)
        {
            var showTime = await _showTimeRepository.GetByIdAsync(id);
            if (showTime == null) return null;

            var responseShowTime = _mapper.Map<ResponseShowTime>(showTime);
            return responseShowTime;
        }

        public async Task<ResponseShowTime?> UpdateShowTimeAsync(int id, UpdateShowTimeModel showTime)
        {
            var oldShowTime =  await _showTimeRepository.GetByIdAsync(id);
            if (oldShowTime == null) return null;

            // Sadece gerekli alanlar güncellenir, navigationlar korunur
            _mapper.Map(showTime, oldShowTime);
            await _showTimeRepository.SaveChangesAsync();

            var responseShowTime = _mapper.Map<ResponseShowTime>(oldShowTime);
            return responseShowTime;
        }

    }
}