public class ResponseTheaterSummary
{
        public required int Id { get; set; }
        
        public required string Name { get; set; }

        public required int SeatCapacity { get; set; }

        public int CinemaId { get; set; }     
}