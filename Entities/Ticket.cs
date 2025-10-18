using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class Ticket
    {
        [Key]
        public required int Id { get; set; }
        
        public required decimal Price { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public bool IsBooked { get; set; } = false;

        public int UserId { get; set; }               // Foreign Key
        public User User { get; set; } = null!;    // Navigation Property

        public int SeatId { get; set; }               // Foreign Key
        public Seat Seat { get; set; } = null!;    // Navigation Property

        public int ShowTimeId { get; set; }               // Foreign Key
        public ShowTime ShowTime { get; set; } = null!;    // Navigation Property

        public int CinemaId { get; set; }               // Foreign Key
        public Cinema Cinema { get; set; } = null!;    // Navigation Property
    }
}