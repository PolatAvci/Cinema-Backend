using CinemaProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Implementations
{
    [ApiController]
    [Route("api/topics")]
    [Authorize(Roles = "Admin")]
    public class TopicController : ControllerBase, ITopicController
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpPost]
        public async Task<ResponseTopic?> CreateTopic([FromBody] CreateTopicModel topicModel)
        {
            var topic = await _topicService.CreateTopicAsync(topicModel);
            return topic;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseTopic>> GetAllTopics()
        {
            var topics = await _topicService.GetAllTopicsAsync();
            return topics;
        }

        [HttpGet("{id}")]
        public async Task<ResponseTopic?> GetTopicById(int id)
        {
            var topic = await _topicService.GetTopicByIdAsync(id);
            return topic;
        }

        [HttpPut("{id}")]
        public async Task<ResponseTopic?> UpdateTopic(int id, [FromBody] UpdateTopicModel topicModel)
        {
            var updatedTopic = await _topicService.UpdateTopicAsync(id, topicModel);
            return updatedTopic;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var deleted = await _topicService.DeleteTopicAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
