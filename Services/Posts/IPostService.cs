using postsAPI.Models.DTOs;
using System.Security.Claims;

namespace postsAPI.Services.Posts
{
    public interface IPostService
    {
        public Task<PostDto> createPostAsync(CreatePostDto dto ,ClaimsPrincipal user);
    }
}
