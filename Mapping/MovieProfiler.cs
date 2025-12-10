using AutoMapper;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
           CreateMap<Movie, ResponseMovieSummary>();

           CreateMap<CreateMovieModel, Movie>()
                .ForMember(dest => dest.Topics, opt => opt.Ignore())
                .ForMember(dest => dest.Actors, opt => opt.Ignore())
                .ForMember(dest => dest.Directors, opt => opt.Ignore())
                .ForMember(dest => dest.ShowTimes, opt => opt.Ignore()); // ShowTimes genellikle create sırasında boş

            // UpdateMovieModel -> Movie
            CreateMap<UpdateMovieModel, Movie>()
                .ForMember(dest => dest.Topics, opt => opt.Ignore())
                .ForMember(dest => dest.Actors, opt => opt.Ignore())
                .ForMember(dest => dest.Directors, opt => opt.Ignore())
                .ForMember(dest => dest.ShowTimes, opt => opt.Ignore());

            // Movie -> ResponseMovie
            CreateMap<Movie, ResponseMovie>()
                .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors))
                .ForMember(dest => dest.ShowTimes, opt => opt.MapFrom(src => src.ShowTimes));
        }
    }
}
