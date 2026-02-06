
namespace DevNet.Repasitories.Post
{
    public interface IPost
    {
        public Task AddPost(DevNet.Models.Post model);
        public Task DeletePost(int id);
        public Task<List<DevNet.Models.Post>> GetAllPosts();
        public Task<DevNet.Models.Post> GetPostById(int id);
        public Task Edit(DevNet.Models.Post model);
    }
}
