using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Enums;

namespace CinemaProject.Mapping
{
    public class DirectorProfile : Profile
    {
        public DirectorProfile()
        {
              CreateMap<CreateDirectorModel, Director>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore()) // Many-to-Many başlangıçta boş
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)));

            // UpdateDirectorModel -> Director
            CreateMap<UpdateDirectorModel, Director>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)));

            // Director -> ResponseDirector
            CreateMap<Director, ResponseDirector>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));

            CreateMap<Director, ResponseDirectorSummary>();
        }
    }
}
