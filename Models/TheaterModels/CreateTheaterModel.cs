// --- Dosya: Models/TheaterModels/CreateTheaterModel.cs ---
using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models.TheaterModels
{
    public class CreateTheaterModel
    {
        [Required] public string Name { get; set; } = null!;
        [Required] public int SeatCapacity { get; set; }
        [Required] public int CinemaId { get; set; } // FK
    }
}