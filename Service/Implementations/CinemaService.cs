// --- Dosya: Service/Implementations/CinemaService.cs ---
using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Models.CinemaModels;
using CinemaProject.Repository.Interfaces; 
using CinemaProject.Service.Interfaces; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Service.Implementations
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IAddressRepository _addressRepository; // Address FK kontrolü için
        private readonly IMapper _mapper;

        public CinemaService(ICinemaRepository cinemaRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ResponseCinema?> CreateCinemaAsync(CreateCinemaModel cinemaModel)
        {
            // İş mantığı: Address FK kontrolü
            var address = await _addressRepository.GetByIdAsync(cinemaModel.AddressId);
            if (address == null) return null; 

            var cinemaEntity = _mapper.Map<Cinema>(cinemaModel);
            await _cinemaRepository.AddAsync(cinemaEntity);
            await _cinemaRepository.SaveChangesAsync();
            
            var createdCinema = await _cinemaRepository.GetCinemaWithDetailsAsync(cinemaEntity.Id);
            return _mapper.Map<ResponseCinema>(createdCinema);
        }
        
        public async Task<IEnumerable<ResponseCinemaSummary>> GetAllCinemasAsync()
        {
            var cinemas = await _cinemaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseCinemaSummary>>(cinemas);
        }

        public async Task<ResponseCinema?> GetCinemaByIdAsync(int id)
        {
            var cinema = await _cinemaRepository.GetCinemaWithDetailsAsync(id);
            if (cinema == null) return null;
            return _mapper.Map<ResponseCinema>(cinema);
        }

        public async Task<ResponseCinema?> UpdateCinemaAsync(int id, UpdateCinemaModel cinemaModel)
        {
            var cinemaToUpdate = await _cinemaRepository.GetByIdAsync(id);
            if (cinemaToUpdate == null) return null;

            if (cinemaModel.AddressId.HasValue && await _addressRepository.GetByIdAsync(cinemaModel.AddressId.Value) == null)
            {
                return null; 
            }

            _mapper.Map(cinemaModel, cinemaToUpdate);
            await _cinemaRepository.SaveChangesAsync();

            var updatedCinema = await _cinemaRepository.GetCinemaWithDetailsAsync(id);
            return _mapper.Map<ResponseCinema>(updatedCinema);
        }

        public async Task<bool> DeleteCinemaAsync(int id)
        {
            var cinemaToDelete = await _cinemaRepository.GetByIdAsync(id);
            if (cinemaToDelete == null) return false;

            _cinemaRepository.Delete(cinemaToDelete);
            await _cinemaRepository.SaveChangesAsync();
            return true;
        }
    }
}