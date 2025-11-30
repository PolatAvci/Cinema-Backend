using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Service.Interfaces
{
    public interface ITopicController
    {
        public Task<ResponseTopic?> CreateTopic(CreateTopicModel topicModel);

        public Task<IEnumerable<ResponseTopic>> GetAllTopics();

        public Task<ResponseTopic?> GetTopicById(int id);

        public Task<IActionResult> DeleteTopic(int id);

        public Task<ResponseTopic?> UpdateTopic(int id, UpdateTopicModel topicModel);
    }
}