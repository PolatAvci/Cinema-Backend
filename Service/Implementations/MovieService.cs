using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using CinemaProject.Service.Interfaces;
using Repository.Interfaces;

namespace CinemaProject.Service.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public MovieService(
            IMovieRepository movieRepository,
            ITopicRepository topicRepository,
            IActorRepository actorRepository,
            IDirectorRepository directorRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _topicRepository = topicRepository;
            _actorRepository = actorRepository;
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task<ResponseMovie> AddShowtimeAsync(int movieId, AddShowTimeToMovieModel showtimeModel)
        {
            var showTime = _mapper.Map<AddShowTimeToMovieModel, ShowTime>(showtimeModel);
            await _movieRepository.AddShowtimeAsync(movieId, showTime);

            var movie = await _movieRepository.GetByIdAsync(movieId);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            await _movieRepository.SaveChangesAsync();

            return _mapper.Map<ResponseMovie>(movie);
        }

        public async Task<ResponseMovie> CreateMovieAsync(CreateMovieModel movieModel)
        {
            var newMovie = _mapper.Map<Movie>(movieModel);

            // İlişkili entityleri ekle
            if (movieModel.TopicIds.Any())
            {
                newMovie.Topics = new List<Topic>();
                foreach (var topicId in movieModel.TopicIds)
                {
                    var topic = await _topicRepository.GetByIdAsync(topicId);
                    if (topic != null)
                        newMovie.Topics.Add(topic);
                }
            }

            if (movieModel.ActorIds.Any())
            {
                newMovie.Actors = new List<Actor>();
                foreach (var actorId in movieModel.ActorIds)
                {
                    var actor = await _actorRepository.GetByIdAsync(actorId);
                    if (actor != null)
                        newMovie.Actors.Add(actor);
                }
            }

            if (movieModel.DirectorIds.Any())
            {
                newMovie.Directors = new List<Director>();
                foreach (var directorId in movieModel.DirectorIds)
                {
                    var director = await _directorRepository.GetByIdAsync(directorId);
                    if (director != null)
                        newMovie.Directors.Add(director);
                }
            }

            await _movieRepository.AddAsync(newMovie);
            await _movieRepository.SaveChangesAsync();

            return _mapper.Map<ResponseMovie>(newMovie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) return false;

            _movieRepository.Delete(movie);
            await _movieRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ResponseMovie>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseMovie>>(movies);
        }

        public async Task<ResponseMovie?> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) return null;

            return _mapper.Map<ResponseMovie>(movie);
        }

        public async Task<ResponseMovie?> UpdateMovieAsync(int id, UpdateMovieModel movieModel)
        {
            var existingMovie = await _movieRepository.GetByIdAsync(id);
            if (existingMovie == null) return null;

            _mapper.Map(movieModel, existingMovie);

            // İlişkili entityleri güncelle
            if (movieModel.TopicIds != null)
            {
                existingMovie.Topics.Clear();
                foreach (var topicId in movieModel.TopicIds)
                {
                    var topic = await _topicRepository.GetByIdAsync(topicId);
                    if (topic != null)
                        existingMovie.Topics.Add(topic);
                }
            }

            if (movieModel.ActorIds != null)
            {
                existingMovie.Actors.Clear();
                foreach (var actorId in movieModel.ActorIds)
                {
                    var actor = await _actorRepository.GetByIdAsync(actorId);
                    if (actor != null)
                        existingMovie.Actors.Add(actor);
                }
            }

            if (movieModel.DirectorIds != null)
            {
                existingMovie.Directors.Clear();
                foreach (var directorId in movieModel.DirectorIds)
                {
                    var director = await _directorRepository.GetByIdAsync(directorId);
                    if (director != null)
                        existingMovie.Directors.Add(director);
                }
            }

            await _movieRepository.SaveChangesAsync();
            return _mapper.Map<ResponseMovie>(existingMovie);
        }
    }
}
