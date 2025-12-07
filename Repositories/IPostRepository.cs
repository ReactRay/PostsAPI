using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;

namespace postsAPI.Repositories
{
    public interface IPostRepository
    {
        public Task<Post?> createPostAsync(Post post);
        public Task<List<Post>> getAllAsync();
        public Task<Post?> getPostById(string Id);
        public Task<Post?> updatePostAsync(UpdatePostDto Post ,string Id ,string userId);

        public Task<Post?> deletePostAsync(string Id);
    }
}
