using AutoMapper;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class ShowTimeProfile : Profile
    {
        public ShowTimeProfile()
        {
            // CreateShowTimeModel → ShowTime
            CreateMap<CreateShowTimeModel, ShowTime>();

            CreateMap<UpdateShowTimeModel, ShowTime>()
                .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Theater, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // TODO: Entity dönmek yerine dto dön
            CreateMap<ShowTime, ResponseShowTime>()
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Theater));

            CreateMap<ShowTime, ResponseShowTimeSummary>();
        }
    }
}