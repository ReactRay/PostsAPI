using postsAPI.Models.Domain;

namespace postsAPI.Repositories
{
    public interface ICommentRepository
    {
        public  Task<Comment?> CreateCommentAsync(Comment comment);

        public Task<Comment?> DeleteCommentAsync(Guid id);



    }
}
