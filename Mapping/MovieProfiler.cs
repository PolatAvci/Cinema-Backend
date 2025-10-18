using AutoMapper;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
           CreateMap<Movie, ResponseMovieSummary>();
        }
    }
}
