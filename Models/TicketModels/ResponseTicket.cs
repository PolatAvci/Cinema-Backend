using CinemaProject.Entities;

public class ResponseTicket
{
    public required int Id { get; set; }
    public required decimal Price { get; set; }
    public required DateTime PurchaseDate { get; set; }
    public bool IsBooked { get; set; } = false;
    public ResponseUserSummary User { get; set; } = null!;
    public ResponseSeatSummary Seat { get; set; } = null!;
    public ResponseShowTimeSummary ShowTime { get; set; } = null!;
    public ResponseCinemaSummary Cinema { get; set; } = null!;
}