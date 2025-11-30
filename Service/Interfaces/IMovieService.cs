namespace Repository.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<ResponseMovie>> GetAllMoviesAsync();

        Task<ResponseMovie?> GetMovieByIdAsync(int id);

        Task<ResponseMovie> CreateMovieAsync(CreateMovieModel movie);

        Task<ResponseMovie?> UpdateMovieAsync(int id, UpdateMovieModel movie);

        Task<bool> DeleteMovieAsync(int id);

        Task<ResponseMovie> AddShowtimeAsync(int movieId, AddShowTimeToMovieModel showtimeModel);
    }
}
