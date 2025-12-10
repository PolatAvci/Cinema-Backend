using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class Topic
    {
        [Key]
        public required int Id { get; set; }

        public required string Name { get; set; }

        public List<Movie> Movies { get; set; } = new(); // Many-to-Many ilişki
    }
}