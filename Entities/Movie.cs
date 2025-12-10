using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class Movie
    {
        [Key]
        public required int Id { get; set; }
        
        public required string Title { get; set; }

        public required DateTime ReleaseDate { get; set; }

        public required TimeOnly Duration { get; set; }

        public required int ImdbRating { get; set; }

        public required string Description { get; set; }

        // One-to-Many ilişki
        public List<ShowTime> ShowTimes { get; set; } = new();

        public List<Topic> Topics { get; set; } = new();

        public List<Actor> Actors { get; set; } = new();

        public List<Director> Directors { get; set; } = new();
    }
}