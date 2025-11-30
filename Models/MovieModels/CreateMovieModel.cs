public class CreateMovieModel
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public int DurationInMinutes { get; set; }

    public decimal Rating { get; set; }

    public List<int> TopicIds { get; set; } = new List<int>();

    public List<int> ActorIds { get; set; } = new List<int>();

    public List<int> DirectorIds { get; set; } = new List<int>();
}