using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Repository.Implementations
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
        }

        public Task AddShowtimeAsync(int movieId, ShowTime showtime)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie != null)
            {
                if (movie.ShowTimes == null)
                {
                    movie.ShowTimes = new List<ShowTime>();
                }
                movie.ShowTimes.Add(showtime);
            }
            return Task.CompletedTask;
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var movies = await _context.Movies
                                       .Include(m => m.ShowTimes)   // Eğer ShowTime ilişkisi varsa
                                       .Include(m => m.Topics)     // Eğer Topic ilişkisi varsa
                                       .Include(m => m.Actors)     // Eğer Actor ilişkisi varsa
                                       .Include(m => m.Directors)  // Eğer Director ilişkisi varsa
                                       .ToListAsync();
            return movies;
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            var movie = await _context.Movies
                                      .Include(m => m.ShowTimes)
                                      .Include(m => m.Topics)
                                      .Include(m => m.Actors)
                                      .Include(m => m.Directors)
                                      .FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
