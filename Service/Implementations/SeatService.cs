using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using Repository.Interfaces;

namespace Service.Implementations
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public SeatService(ISeatRepository seatRepository, IMapper mapper)
        {
            _seatRepository = seatRepository;
            _mapper = mapper;
        }
        
        public async Task<ResponseSeat> CreateSeatAsync(CreateSeatModel seat)
        {
            var newSeat = _mapper.Map<Seat>(seat);
            await _seatRepository.AddAsync(newSeat);
            await _seatRepository.SaveChangesAsync();

            var fullSeat = await _seatRepository.GetByIdAsync(newSeat.Id);

            var responseSeat = _mapper.Map<ResponseSeat>(fullSeat);
            return responseSeat;
        }

        public async Task<bool> DeleteSeatAsync(int id)
        {
            var seat = await _seatRepository.GetByIdAsync(id);

            if (seat == null)
            {
                return false;
            }

            _seatRepository.Delete(seat);
            await _seatRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ResponseSeat>> GetAllSeatAsync()
        {
            var seats = await _seatRepository.GetAllAsync();
            var responseSeats = _mapper.Map<IEnumerable<ResponseSeat>>(seats);
            return responseSeats;
        }

        public async Task<ResponseSeat?> GetSeatByIdAsync(int id)
        {
            var seat = await _seatRepository.GetByIdAsync(id);

            if (seat == null)
            {
                return null;
            }

            var responseSeat = _mapper.Map<ResponseSeat>(seat);
            return responseSeat;
        }

        public async Task<ResponseSeat?> UpdateSeatAsync(int id, UpdateSeatModel seat)
        {
            var oldSeat = await _seatRepository.GetByIdAsync(id);

            if (oldSeat == null)
            {
                return null;
            }

            _mapper.Map(seat, oldSeat);
            await _seatRepository.SaveChangesAsync();

            var responseSeat = _mapper.Map<ResponseSeat>(oldSeat);
            return responseSeat;

        }
    }
}