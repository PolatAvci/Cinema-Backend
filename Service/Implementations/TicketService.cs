using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using CinemaProject.Service.Interfaces;

namespace CinemaProject.Service.Implementations
{
    public class TicketService : ITicketService
    {
        private IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;

        public TicketService(IMapper mapper, ITicketRepository ticketRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        public async Task<ResponseTicket> CreateTicketAsync(CreateTicketModel ticket)
        {
            var newTicket = _mapper.Map<Ticket>(ticket);
            newTicket.PurchaseDate = null;
            
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
    }
}