using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class ShowTime
    {
        [Key]
        public required int Id { get; set; }
        
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }

        public decimal FullPrice { get; set; }

        public decimal StudentPrice { get; set; }

        public int MovieId { get; set; }               // Foreign Key
        public Movie Movie { get; set; } = null!;    // Navigation Property

        public int TheaterId { get; set; }               // Foreign Key
        public Theater Theater { get; set; } = null!;    // Navigation Property

        public List<Ticket> Tickets { get; set; } = new(); // One-to-Many ilişki

    }
}