using CinemaProject.Entities;

namespace CinemaProject.Repository.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();

        Task<Movie?> GetByIdAsync(int id);

        Task AddAsync(Movie movie);

        void Delete(Movie movie);

        Task SaveChangesAsync();

        Task AddShowtimeAsync(int movieId, ShowTime showtime);
    }
}
