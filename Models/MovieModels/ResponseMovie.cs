public class ResponseMovie
{
    public required int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required DateTime ReleaseDate { get; set; }

    public required TimeOnly Duration { get; set; }

    public required int ImdbRating { get; set; }

    public List<ResponseTopicSummary> Topics { get; set; } = new();

    public List<ResponseActorSummary> Actors { get; set; } = new();

    public List<ResponseDirectorSummary> Directors { get; set; } = new();

    public List<ResponseShowTimeSummary> ShowTimes { get; set; } = new();
}