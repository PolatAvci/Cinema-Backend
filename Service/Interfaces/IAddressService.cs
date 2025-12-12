using CinemaProject.Models.AddressModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CinemaProject.Service.Interfaces
{
    public interface IAddressService
    {
        Task<ResponseAddress?> CreateAddressAsync(CreateAddressModel addressModel);
        Task<IEnumerable<ResponseAddress>> GetAllAddressesAsync();
        Task<ResponseAddress?> GetAddressByIdAsync(int id);
        Task<ResponseAddress?> UpdateAddressAsync(int id, UpdateAddressModel addressModel);
        Task<bool> DeleteAddressAsync(int id);
    }
}