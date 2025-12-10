using CinemaProject.Controller.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;


namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase, IMovieController
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("{movieId}/showtimes")]
        public async Task<ResponseMovie> AddShowtime(int movieId, AddShowTimeToMovieModel showtimeModel)
        {
            var response = await _movieService.AddShowtimeAsync(movieId, showtimeModel);
            return response;
        }

        [HttpPost]
        public Task<ResponseMovie> CreateMovie(CreateMovieModel movieModel)
        {
            var movie = _movieService.CreateMovieAsync(movieModel);
            return movie;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);

            if(!result)
            {
                return NotFound();
            }

            return NoContent();
            
        }

        [HttpGet]
        public Task<IEnumerable<ResponseMovie>> GetAllMovies()
        {
            var movies = _movieService.GetAllMoviesAsync();
            return movies;
        }

        [HttpGet("{id}")]
        public Task<ResponseMovie?> GetMovieById(int id)
        {
            var movie = _movieService.GetMovieByIdAsync(id);
            return movie;
        }

        [HttpPut("{id}")]
        public Task<ResponseMovie?> UpdateMovie(int id, UpdateMovieModel movieModel)
        {
            var movie = _movieService.UpdateMovieAsync(id, movieModel);
            return movie;
        }
    }
}