using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Models.TheaterModels;

namespace CinemaProject.Mapping
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
           CreateMap<CreateTheaterModel, Theater>()
                .ForMember(dest => dest.Cinema, opt => opt.Ignore())
                .ForMember(dest => dest.Seats, opt => opt.Ignore())
                .ForMember(dest => dest.ShowTimes, opt => opt.Ignore());

            CreateMap<UpdateTheaterModel, Theater>()
                .ForMember(dest => dest.Cinema, opt => opt.Ignore())
                .ForMember(dest => dest.Seats, opt => opt.Ignore())
                .ForMember(dest => dest.ShowTimes, opt => opt.Ignore());

           
            CreateMap<Theater, ResponseTheaterSummary>();
            CreateMap<Theater, ResponseTheater>(); 
        }
    }
}
