public class ResponseMovie
{
public required int Id { get; set; }
        
        public required string Title { get; set; }

        public required DateTime ReleaseDate { get; set; }

        public required TimeOnly Duration { get; set; }

        public required int ImdbRating { get; set; }

        public required string Description { get; set; }
}