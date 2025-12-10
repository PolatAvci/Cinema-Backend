// --- DÜZELTİLMİŞ KOD ---

// using System.ComponentModel.DataAnnotations; // Response olduğu için bu gereksiz

namespace CinemaProject.Models.CinemaModels // <<< DOĞRU NAMESPACE BURASI OLMALI
{
    public class ResponseCinemaSummary
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        
        // Response modelde sadece foreign key'i göstermek yaygın bir pratiktir, ancak
        // eğer bu summary liste ekranları içinse FK'ya da gerek kalmayabilir.
        public int AddressId { get; set; } 
    }
}