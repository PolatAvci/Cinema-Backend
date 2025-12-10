using AutoMapper;
using CinemaProject.Entities;

namespace CinemaProject.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, User>()
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Tickets, opt => opt.Ignore()) // Tickets başlangıçta boş
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Id DB tarafından atanacak

            CreateMap<User, ResponseUser>();

            CreateMap<User, ResponseUserSummary>();
        }
    }
}
