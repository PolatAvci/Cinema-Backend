using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Models.CinemaModels;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        // Summary
        CreateMap<Cinema, ResponseCinemaSummary>();

        // Detail
        CreateMap<Cinema, ResponseCinema>();

        // Update Cinema
        CreateMap<UpdateCinemaModel, Cinema>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Id değiştirilmez
    }
}
