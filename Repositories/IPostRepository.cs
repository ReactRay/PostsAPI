using postsAPI.Models.Domain;

namespace postsAPI.Repositories
{
    public interface IPostRepository
    {
        public Task<Post?> createPostAsync(Post post);
        public Task<List<Post>> getAllAsync();
    }
}
