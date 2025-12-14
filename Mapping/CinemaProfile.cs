using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Models.CinemaModels;

namespace CinemaProject.Mapping
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
           CreateMap<Cinema, ResponseCinemaSummary>();

            // Detail
            CreateMap<Cinema, ResponseCinema>();

            CreateMap<CreateCinemaModel, Cinema>();

            // Update Cinema
            CreateMap<UpdateCinemaModel, Cinema>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Id değiştirilmez
        }
    }
}