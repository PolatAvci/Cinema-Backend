using AutoMapper;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<Seat, ResponseSeatSummary>();

            CreateMap<CreateSeatModel, Seat>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore())
                .ForMember(dest => dest.Theater, opt => opt.Ignore());

            CreateMap<Seat, ResponseSeat>()
                .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Theater));
                
            CreateMap<UpdateSeatModel, Seat>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Theater, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());
        }
    }
}