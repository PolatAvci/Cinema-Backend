using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class Cinema
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }

        // One-to-One ilişki
        public int AddressId { get; set; }               // Foreign Key
        public Address Address { get; set; } = null!;    // Navigation Property

        // One-to-Many ilişki
        public List<Theater> Theaters { get; set; } = new();

        public List<Ticket> Tickets { get; set; } = new(); // One-to-Many ilişki
    }
}