using postsAPI.Models.DTOs;
using System.Security.Claims;

namespace postsAPI.Services.Comments
{
    public interface ICommentService
    {
        public Task<CommentDto> createComment(CreateCommentDto dto, ClaimsPrincipal user);
    }
}
