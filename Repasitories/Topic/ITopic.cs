using DevNet.Models;
namespace DevNet.Repasitories.Topic
{
    public interface ITopic
    {
        Task<IEnumerable<Models.Topic>> GetAllTopicsAsync();
        Task<Models.Topic> GetTopicById(int id);

        Task CreateTopic(Models.Topic topic);
        Task UpdateTopic(Models.Topic topic);
        Task DeleteTopic(int id);
    }
}
