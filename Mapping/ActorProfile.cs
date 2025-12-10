using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Enums;

namespace CinemaProject.Mapping
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<CreateActorModel, Actor>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore()) // Movies başlangıçta boş
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender))); // string -> enum

            // UpdateActorModel -> Actor
            CreateMap<UpdateActorModel, Actor>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)));

            // Actor -> ResponseActor
            CreateMap<Actor, ResponseActor>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString())); // enum -> string
                
            CreateMap<Actor, ResponseActorSummary>();
        }
    }
}
