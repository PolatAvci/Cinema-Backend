
public class ResponseTiceketSummary
{
    public required int Id { get; set; }

    public required decimal Price { get; set; }

    public required DateTime PurchaseDate { get; set; }

    public bool IsBooked { get; set; } = false;

    public int UserId { get; set; }

    public int SeatId { get; set; }

    public int ShowTimeId { get; set; }

    public int CinemaId { get; set; }
}
