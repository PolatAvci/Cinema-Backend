using AutoMapper;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
           CreateMap<Theater, ResponseTheater>();
        }
    }
}
