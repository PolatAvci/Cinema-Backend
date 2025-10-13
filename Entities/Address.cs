using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }

        public required string Neighbourhood { get; set; }

        public required string Street { get; set; }

        // Opsiyonel navigation (karşı taraf)
        public Cinema? Cinema { get; set; }
    }
}