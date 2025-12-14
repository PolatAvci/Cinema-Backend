// --- Dosya: Models/CinemaModels/ResponseCinema.cs ---
using CinemaProject.Models.AddressModels;


namespace CinemaProject.Models.CinemaModels
{
    public class ResponseCinema
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        
        public ResponseAddress? Address { get; set; } 
    }
}