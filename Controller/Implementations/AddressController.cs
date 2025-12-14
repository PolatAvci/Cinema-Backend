// --- Dosya: Controller/Implementations/AddressController.cs ---
using CinemaProject.Controller.Interfaces;
using CinemaProject.Models.AddressModels;
using CinemaProject.Service.Interfaces; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/addresses")]
    [Authorize(Roles = "Admin")]
    public class AddressController : ControllerBase, IAddressController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseAddress?>> CreateAddress([FromBody] CreateAddressModel addressModel)
        {
            var address = await _addressService.CreateAddressAsync(addressModel);
            if (address == null) return BadRequest();
            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ResponseAddress>> GetAllAddresses() => await _addressService.GetAllAddressesAsync();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseAddress?>> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address == null) return NotFound();
            return address;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseAddress?>> UpdateAddress(int id, [FromBody] UpdateAddressModel addressModel)
        {
            var updated = await _addressService.UpdateAddressAsync(id, addressModel);
            if (updated == null) return NotFound();
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var deleted = await _addressService.DeleteAddressAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}