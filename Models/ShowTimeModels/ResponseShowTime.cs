using CinemaProject.Entities;

public class ResponseShowTime
{
    public required int Id { get; set; }

    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }

    public decimal FullPrice { get; set; }

    public decimal StudentPrice { get; set; }

    public ResponseMovieSummary Movie { get; set; } = null!;

    public ResponseTheaterSummary Theater { get; set; } = null!;
}