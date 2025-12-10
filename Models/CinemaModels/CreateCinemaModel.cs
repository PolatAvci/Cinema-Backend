// --- Dosya: Models/CinemaModels/CreateCinemaModel.cs ---
using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models.CinemaModels
{
    public class CreateCinemaModel
    {
        [Required] public string Name { get; set; } = null!;
        [Required] public string Location { get; set; } = null!;
        [Required] public int AddressId { get; set; } // FK
    }
}