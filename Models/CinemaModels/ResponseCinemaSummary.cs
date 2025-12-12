

// using System.ComponentModel.DataAnnotations; // Response olduğu için bu gereksiz

namespace CinemaProject.Models.CinemaModels 
{
    public class ResponseCinemaSummary
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        
       
        public int AddressId { get; set; } 
    }
}