// --- Dosya: Service/Implementations/TheaterService.cs ---
using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Models.TheaterModels;
using CinemaProject.Repository.Interfaces;
using CinemaProject.Service.Interfaces;
using System.Threading.Tasks;

namespace CinemaProject.Service.Implementations
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;
        private readonly ICinemaRepository _cinemaRepository; // FK kontrolü için
        private readonly IMapper _mapper;

        public TheaterService(ITheaterRepository theaterRepository, ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _theaterRepository = theaterRepository;
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<ResponseTheater?> CreateTheaterAsync(CreateTheaterModel theaterModel)
        {
            // İş Kuralı: CinemaId geçerli mi kontrolü
            var cinema = await _cinemaRepository.GetByIdAsync(theaterModel.CinemaId);
            if (cinema == null) return null;

            var theaterEntity = _mapper.Map<Theater>(theaterModel);
            await _theaterRepository.AddAsync(theaterEntity);
            await _theaterRepository.SaveChangesAsync();
            
            // Detayları (Seats, Cinema) çekerek dönüştürme
            var createdTheater = await _theaterRepository.GetTheaterWithDetailsAsync(theaterEntity.Id);
            return _mapper.Map<ResponseTheater>(createdTheater);
        }
        
        // ... (Diğer CRUD metotları)
        
        public async Task<IEnumerable<ResponseTheaterSummary>> GetAllTheatersAsync()
        {
            var theaters = await _theaterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseTheaterSummary>>(theaters);
        }
        
        public async Task<ResponseTheater?> GetTheaterByIdAsync(int id)
        {
            var theater = await _theaterRepository.GetTheaterWithDetailsAsync(id);
            if (theater == null) return null;
            return _mapper.Map<ResponseTheater>(theater);
        }

        public async Task<ResponseTheater?> UpdateTheaterAsync(int id, UpdateTheaterModel theaterModel)
        {
            var theaterToUpdate = await _theaterRepository.GetByIdAsync(id);
            if (theaterToUpdate == null) return null;

            if (theaterModel.CinemaId.HasValue && await _cinemaRepository.GetByIdAsync(theaterModel.CinemaId.Value) == null)
            {
                return null;
            }

            _mapper.Map(theaterModel, theaterToUpdate);
            await _theaterRepository.SaveChangesAsync();
            
            var updatedTheater = await _theaterRepository.GetTheaterWithDetailsAsync(id);
            return _mapper.Map<ResponseTheater>(updatedTheater);
        }

        public async Task<bool> DeleteTheaterAsync(int id)
        {
            var theaterToDelete = await _theaterRepository.GetByIdAsync(id);
            if (theaterToDelete == null) return false;

            _theaterRepository.Delete(theaterToDelete);
            await _theaterRepository.SaveChangesAsync();
            return true;
        }
    }
}