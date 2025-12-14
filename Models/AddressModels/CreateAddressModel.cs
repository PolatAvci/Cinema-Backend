using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models.AddressModels
{
    public class CreateAddressModel
    {
        [Required] public string Country { get; set; } = null!;
        [Required] public string City { get; set; } = null!;
        [Required] public string State { get; set; } = null!; // Eyalet/İlçe
        [Required] public string Neighbourhood { get; set; } = null!; // Mahalle
        [Required] public string Street { get; set; } = null!; // Sokak/Cadde
    }
}