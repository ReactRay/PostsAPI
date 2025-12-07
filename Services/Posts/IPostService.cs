using postsAPI.Models.DTOs;
using System.Security.Claims;

namespace postsAPI.Services.Posts
{
    public interface IPostService
    {
        public Task<PostDto> createPostAsync(CreatePostDto dto ,ClaimsPrincipal user);

        public Task<List<PostDto>> getAllPostsAsync();

        public Task<PostDto> UpdatePostAsync(UpdatePostDto updates ,string id,ClaimsPrincipal user);

        public Task<PostDto> getPostById(string id);


        public Task<PostDto> deletePost(Guid id ,ClaimsPrincipal user);
    }
}
