using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Interfaces
{
    public interface IMovieController
    {
        public Task<ResponseMovie> CreateMovie(CreateMovieModel movieModel);

        public Task<IEnumerable<ResponseMovie>> GetAllMovies();

        public Task<ResponseMovie?> GetMovieById(int id);

        public Task<IActionResult> DeleteMovie(int id);

        public Task<ResponseMovie?> UpdateMovie(int id, UpdateMovieModel movieModel);

        public Task<ResponseMovie> AddShowtime(int movieId, AddShowTimeToMovieModel showtimeModel);
    }
}
