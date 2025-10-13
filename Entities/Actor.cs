using System.ComponentModel.DataAnnotations;
using CinemaProject.Enums;

namespace CinemaProject.Entities
{
    public class Actor
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }

        public required DateTime BirthDate { get; set; }

        public required Gender Gender { get; set; }

        public List<Movie> Movies { get; set; } = new(); // Many-to-Many ilişki
    }
}