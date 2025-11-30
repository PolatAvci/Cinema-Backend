using CinemaProject.Entities;
using AutoMapper;

namespace CinemaProject.Mapping
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<CreateTopicModel, Topic>();
            CreateMap<UpdateTopicModel, Topic>();
            CreateMap<Topic, ResponseTopic>();
            CreateMap<Topic, ResponseTopicSummary>();
        }
    }
}