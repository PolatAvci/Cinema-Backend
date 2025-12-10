namespace CinemaProject.Models.AddressModels
{
    public class ResponseAddress
    {
        public required int Id { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Neighbourhood { get; set; }
        public required string Street { get; set; }
    }
}