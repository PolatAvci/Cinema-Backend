using AutoMapper;
using CinemaProject.Data;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;

namespace CinemaProject.Repository.Implementations
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TopicRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task AddAsync(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
        }

        public Task<IEnumerable<Topic>> GetAllAsync()
        {
            var topics = _context.Topics.AsEnumerable();
            return Task.FromResult(topics);
        }

        public Task<Topic?> GetByIdAsync(int id)
        {
            var topic = _context.Topics.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(topic);
        }

        public void Delete(Topic topic)
        {
            _context.Topics.Remove(topic);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}