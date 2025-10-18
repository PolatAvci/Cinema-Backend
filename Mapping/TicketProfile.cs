using AutoMapper;
using Azure;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<CreateTicketModel, Ticket>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Seat, opt => opt.Ignore())
                .ForMember(dest => dest.ShowTime, opt => opt.Ignore())
                .ForMember(dest => dest.Cinema, opt => opt.Ignore());


            CreateMap<Ticket, ResponseTicket>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Seat, opt => opt.MapFrom(src => src.Seat))
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => src.ShowTime))
                .ForMember(dest => dest.Cinema, opt => opt.MapFrom(src => src.Cinema));
            
            
            CreateMap<UpdateTicketModel, Ticket>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Seat, opt => opt.Ignore())
                .ForMember(dest => dest.ShowTime, opt => opt.Ignore())
                .ForMember(dest => dest.Cinema, opt => opt.Ignore());

        }
    }
}