
using Microsoft.EntityFrameworkCore;

namespace DevNet.Repasitories.Topic
{
    public class TopicService : ITopic
    {
        private readonly AppDbContext _context;
        public TopicService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateTopic(Models.Topic topic)
        {
            topic.CreatedAt = DateTime.UtcNow;
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Models.Topic>> GetAllTopicsAsync()
        {
            return await _context.Topics.ToListAsync();

        }

        public async Task<Models.Topic> GetTopicById(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            return topic;
        }

        public async Task UpdateTopic(Models.Topic topic)
        {
            _context.Topics.Update(topic);
            await _context.SaveChangesAsync();
        }
    }
}
