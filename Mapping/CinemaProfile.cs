using AutoMapper;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
           CreateMap<Cinema, ResponseCinemaSummary>();
        }
    }
}