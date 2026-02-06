using DevNet.Models;
using Microsoft.EntityFrameworkCore;
namespace DevNet.Repasitories.Post
{
    public class PostService : IPost
    {
        private readonly AppDbContext _context;
        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(Models.Post model)
        {
            model.CreatedAt = DateTime.UtcNow;
            await _context.Posts.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }


        public async Task Edit(Models.Post model)
        {
            _context.Posts.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Models.Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Models.Post> GetPostById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }
    }
}
