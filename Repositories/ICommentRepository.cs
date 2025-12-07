using postsAPI.Models.Domain;
using System.Security.Claims;

namespace postsAPI.Repositories
{
    public interface ICommentRepository
    {
        public  Task<Comment?> CreateCommentAsync(Comment comment, ClaimsPrincipal user);

        public Task<Comment?> DeleteCommentAsync(Guid id , Guid userId);



    }
}
