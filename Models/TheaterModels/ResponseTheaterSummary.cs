// --- Dosya: Models/TheaterModels/ResponseTheaterSummary.cs ---
namespace CinemaProject.Models.TheaterModels
{
    public class ResponseTheaterSummary
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int SeatCapacity { get; set; }
        public required int CinemaId { get; set; }
    }
}