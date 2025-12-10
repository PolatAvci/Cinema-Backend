using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class Seat
    {
        [Key]
        public required int Id { get; set; }

        public required string SeatNumber { get; set; }

        // Many-to-One ilişki
        public int TheaterId { get; set; }               // Foreign Key
        public Theater Theater { get; set; } = null!;    // Navigation Property

        public List<Ticket> Tickets { get; set; } = new(); // One-to-Many ilişki
    }
}