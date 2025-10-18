public class UpdateShowTimeModel
{
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }

    public decimal FullPrice { get; set; }

    public decimal StudentPrice { get; set; }

    public int MovieId { get; set; }

    public int TheaterId { get; set; }
}