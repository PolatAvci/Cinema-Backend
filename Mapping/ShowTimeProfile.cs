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

            // TODO: Entity dönmek yerine dto dön
             CreateMap<ShowTime, ResponseShowTime>()
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Theater));
        }
    }
}