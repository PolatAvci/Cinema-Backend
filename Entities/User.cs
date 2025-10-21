using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Entities
{
    public class User
    {
        [Key]
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required Role Role { get; set; } = Role.User;

        public required string Password { get; set; }

        public required DateTime RegistrationDate { get; set; } = DateTime.Now;

        public required DateTime BirthDate { get; set; }

        // One-to-Many ilişki
        public List<Ticket> Tickets { get; set; } = new();
    }
}