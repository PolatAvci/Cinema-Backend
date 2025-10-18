using AutoMapper;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<Seat, ResponseSeatSummary>();
        }
    }
}