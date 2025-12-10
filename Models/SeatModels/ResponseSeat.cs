public class ResponseSeat
{
    public required int Id { get; set; }

    public required string SeatNumber { get; set; }

    public ResponseTheaterSummary Theater { get; set; } = null!;
}