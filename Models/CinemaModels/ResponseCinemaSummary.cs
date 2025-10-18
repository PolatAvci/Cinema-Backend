using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class ResponseCinemaSummary
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public int AddressId { get; set; }
    }
}