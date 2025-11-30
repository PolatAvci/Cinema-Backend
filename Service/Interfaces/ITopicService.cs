namespace CinemaProject.Service.Interfaces
{
    public interface ITopicService
    {
        Task<ResponseTopic?> CreateTopicAsync(CreateTopicModel topicModel);
        Task<IEnumerable<ResponseTopic>> GetAllTopicsAsync();
        Task<ResponseTopic?> GetTopicByIdAsync(int id);
        Task<ResponseTopic?> UpdateTopicAsync(int id, UpdateTopicModel topicModel);
        Task<bool> DeleteTopicAsync(int id);
    }
}