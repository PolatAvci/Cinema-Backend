// --- Dosya: Mapping/AddressProfile.cs ---
using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Models.AddressModels;
namespace CinemaProject.Mapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressModel, Address>().ForMember(dest => dest.Cinema, opt => opt.Ignore());
            CreateMap<UpdateAddressModel, Address>().ForMember(dest => dest.Cinema, opt => opt.Ignore());
            CreateMap<Address, ResponseAddress>();
        }
    }
}