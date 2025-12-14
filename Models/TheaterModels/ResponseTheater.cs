// --- Dosya: Models/TheaterModels/ResponseTheater.cs ---
using CinemaProject.Entities;
using CinemaProject.Models.CinemaModels; // Cinema detayını göstermek için


namespace CinemaProject.Models.TheaterModels
{
    public class ResponseTheater
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int SeatCapacity { get; set; }

       
        public required int CinemaId { get; set; }
        public ResponseCinemaSummary? CinemaSummary { get; set; }

        public List<ResponseSeatSummary> Seats { get; set; } = new(); 
    }
}