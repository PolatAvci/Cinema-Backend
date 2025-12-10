using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using CinemaProject.Service.Interfaces;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace CinemaProject.Service.Implementations
{
    public class TicketService : ITicketService
    {
        private IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;

        private readonly ISeatRepository _seatRepository;

        public TicketService(IMapper mapper, ITicketRepository ticketRepository, ISeatRepository seatRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _seatRepository = seatRepository;
        }

        public async Task<ResponseTicket> CreateTicketAsync(CreateTicketModel ticket)
        {
            var newTicket = _mapper.Map<Ticket>(ticket);

            var seat = await _seatRepository.GetByIdWithDetailsAsync(ticket.SeatId);
            if (seat == null)
                throw new Exception("Seat not found.");

            var cinemaId = seat.Theater.CinemaId;

            newTicket.CinemaId = cinemaId;

            await _ticketRepository.AddAsync(newTicket);
            await _ticketRepository.SaveChangesAsync();

            var fullTicket = await _ticketRepository.GetByIdAsync(newTicket.Id); // ShowTime, User ve Seat dahil

            var responseTicket = _mapper.Map<ResponseTicket>(fullTicket);
            return responseTicket;
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
                return false;

            _ticketRepository.Delete(ticket);
            await _ticketRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ResponseTicket>> GetAllTicketAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            var responseTickets = _mapper.Map<IEnumerable<ResponseTicket>>(tickets);
            return responseTickets;
        }

        public async Task<ResponseTicket?> GetTicketByIdAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null) return null;

            var responseTicket = _mapper.Map<ResponseTicket>(ticket);
            return responseTicket;
        }

        public async Task<ResponseTicket?> UpdateTicketAsync(int id, UpdateTicketModel ticket)
        {
            var oldTicket = await _ticketRepository.GetByIdAsync(id);
            if (oldTicket == null) return null;

            _mapper.Map(ticket, oldTicket);
            await _ticketRepository.SaveChangesAsync();

            return _mapper.Map<ResponseTicket>(oldTicket);
        }

        public async Task<ResponseTicket?> BuyTicketAsync(int ticketId, BuyTicketModel buyTicketModel)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);

            if (ticket == null)
                throw new Exception("Ticket not found.");

            if (ticket.IsBooked)
                throw new Exception("Ticket is already purchased.");

            // TODO: Price user'ın öğrenci olup olmamasına göre ayarlanabilir (showTime'da öğrenci ve normal fiyat var)
            ticket.UserId = buyTicketModel.UserId;
            ticket.PurchaseDate = DateTime.UtcNow;
            ticket.IsBooked = true;

            // Öğrenci ise öğrenci fiyatı, değilse tam fiyatı ata
            if (buyTicketModel.Role == Role.Student)
                ticket.Price = ticket.ShowTime.StudentPrice;
            else
                ticket.Price = ticket.ShowTime.FullPrice;
                

            await _ticketRepository.SaveChangesAsync();

            var fullTicket = await _ticketRepository.GetByIdAsync(ticket.Id); // User'ı da dahil et

            var responseTicket = _mapper.Map<ResponseTicket>(fullTicket);

            return responseTicket;
        }
    }
}