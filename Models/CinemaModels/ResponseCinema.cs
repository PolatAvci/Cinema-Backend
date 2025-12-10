// --- Dosya: Models/CinemaModels/ResponseCinema.cs ---
using CinemaProject.Models.AddressModels;
// using CinemaProject.Models.TheaterModels; // Theater'dan sonra eklenecek

namespace CinemaProject.Models.CinemaModels
{
    public class ResponseCinema
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        
        public ResponseAddress? Address { get; set; } // İlişkili Adres
        
        // public List<ResponseTheaterSummary> Theaters { get; set; } = new(); // Theater tamamlanınca açılacak
    }
}