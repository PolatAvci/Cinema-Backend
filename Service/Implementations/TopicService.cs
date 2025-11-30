using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Repository.Interfaces;
using CinemaProject.Service.Interfaces;

namespace CinemaProject.Service.Implementations
{
    public class TopicService : ITopicService
    {
        private readonly IMapper _mapper;
        private readonly ITopicRepository _topicRepository;

        public TopicService(IMapper mapper, ITopicRepository topicRepository)
        {
            _mapper = mapper;
            _topicRepository = topicRepository;
        }

        public async Task<ResponseTopic?> CreateTopicAsync(CreateTopicModel topicModel)
        {
            var topic = _mapper.Map<Topic>(topicModel);

            await _topicRepository.AddAsync(topic);
            await _topicRepository.SaveChangesAsync();

            return _mapper.Map<ResponseTopic>(topic);
        }

        public async Task<IEnumerable<ResponseTopic>> GetAllTopicsAsync()
        {
            var topics = await _topicRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseTopic>>(topics);
        }

        public async Task<ResponseTopic?> GetTopicByIdAsync(int id)
        {
            var topic = await _topicRepository.GetByIdAsync(id);
            if (topic == null) return null;

            return _mapper.Map<ResponseTopic>(topic);
        }

        public async Task<ResponseTopic?> UpdateTopicAsync(int id, UpdateTopicModel topicModel)
        {
            var oldTopic = await _topicRepository.GetByIdAsync(id);
            if (oldTopic == null) return null;

            _mapper.Map(topicModel, oldTopic);
            await _topicRepository.SaveChangesAsync();

            return _mapper.Map<ResponseTopic>(oldTopic);
        }

        public async Task<bool> DeleteTopicAsync(int id)
        {
            var topic = await _topicRepository.GetByIdAsync(id);
            if (topic == null) return false;

            _topicRepository.Delete(topic);
            await _topicRepository.SaveChangesAsync();
            return true;
        }
    }
}
