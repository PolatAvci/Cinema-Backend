
public class CreateTicketModel
{
    public required decimal Price { get; set; }

    public int UserId { get; set; }

    public int SeatId { get; set; }

    public int ShowTimeId { get; set; }

    public int CinemaId { get; set; }

}