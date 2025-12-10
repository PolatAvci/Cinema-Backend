

namespace CinemaProject.Models.SeatModels 
{
    public class ResponseSeatSummary
    {
        public required int Id { get; set; }
        public required string SeatNumber { get; set; }
        public int TheaterId { get; set; }
    }
}