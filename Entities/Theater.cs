using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class Theater
    {
        [Key]
        public required int Id { get; set; }
        
        public required string Name { get; set; }

        public required int SeatCapacity { get; set; }

        // Many-to-One ilişki
        public int CinemaId { get; set; }               // Foreign Key
        public Cinema Cinema { get; set; } = null!;    // Navigation Property

        // One-to-Many ilişki
        public List<Seat> Seats { get; set; } = new();

        public List<ShowTime> ShowTimes { get; set; } = new();
    }
}