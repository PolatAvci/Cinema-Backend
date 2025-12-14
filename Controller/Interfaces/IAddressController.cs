// --- Dosya: Controller/Interfaces/IAddressController.cs ---
using CinemaProject.Models.AddressModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Interfaces
{
    public interface IAddressController
    {
        Task<ActionResult<ResponseAddress?>> CreateAddress(CreateAddressModel addressModel);
        Task<IEnumerable<ResponseAddress>> GetAllAddresses();
        Task<ActionResult<ResponseAddress?>> GetAddressById(int id);
        Task<ActionResult<ResponseAddress?>> UpdateAddress(int id, UpdateAddressModel addressModel);
        Task<IActionResult> DeleteAddress(int id);
    }
}