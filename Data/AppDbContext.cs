using Microsoft.EntityFrameworkCore;
using CinemaProject.Entities;

namespace CinemaProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Cinema> Cinemas { get; set; } = null!;
        public DbSet<Director> Directors { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Seat> Seats { get; set; } = null!;
        public DbSet<ShowTime> ShowTimes { get; set; } = null!;
        public DbSet<Theater> Theaters { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Actor - Movie (Many-to-Many)
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.Movies)
                .WithMany(m => m.Actors)
                .UsingEntity<Dictionary<string, object>>(
                    "ActorMovies",
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    j => j.HasOne<Actor>().WithMany().HasForeignKey("ActorId"),
                    j =>
                    {
                        j.HasKey("ActorId", "MovieId");
                        j.ToTable("ActorMovies");
                    });

            // Director - Movie (Many-to-Many)
            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movies)
                .WithMany(m => m.Directors)
                .UsingEntity<Dictionary<string, object>>(
                    "DirectorMovies",
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    j => j.HasOne<Director>().WithMany().HasForeignKey("DirectorId"),
                    j =>
                    {
                        j.HasKey("DirectorId", "MovieId");
                        j.ToTable("DirectorMovies");
                    });

            // Cinema - Theater (One-to-Many)
            modelBuilder.Entity<Cinema>()
                .HasMany(c => c.Theaters)
                .WithOne(t => t.Cinema)
                .HasForeignKey(t => t.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cinema - Ticket (One-to-Many)
            modelBuilder.Entity<Cinema>()
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Cinema)
                .HasForeignKey(t => t.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cinema - Address (One-to-One)
            modelBuilder.Entity<Cinema>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Cinema)
                .HasForeignKey<Cinema>(c => c.AddressId);


            // Movie - ShowTime (One-to-Many)
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.ShowTimes)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // Topic - Movie (Many-to-Many)
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.Movies)
                .WithMany(m => m.Topics)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieTopics",
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    j => j.HasOne<Topic>().WithMany().HasForeignKey("TopicId"),
                    j =>
                    {
                        j.HasKey("MovieId", "TopicId");
                        j.ToTable("MovieTopics");
                    });

            // Seat - Theater (Many-to-One)
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Theater)
                .WithMany(t => t.Seats)
                .HasForeignKey(s => s.TheaterId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seat - Ticket (One-to-Many)
            modelBuilder.Entity<Seat>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.Seat)
                .HasForeignKey(t => t.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

            // ShowTime - Theater (Many-to-One)
            modelBuilder.Entity<ShowTime>()
                .HasOne(st => st.Theater)
                .WithMany(t => t.ShowTimes)
                .HasForeignKey(st => st.TheaterId)
                .OnDelete(DeleteBehavior.Cascade);

            // ShowTime - Ticket (One-to-Many)
            modelBuilder.Entity<ShowTime>()
                .HasMany(st => st.Tickets)
                .WithOne(t => t.ShowTime)
                .HasForeignKey(t => t.ShowTimeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ticket - User (Many-to-One)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
