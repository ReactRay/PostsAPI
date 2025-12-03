using Microsoft.EntityFrameworkCore;
using postsAPI.Data;
using postsAPI.Models.Domain;

namespace postsAPI.Repositories
{
    public class SQLcommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public SQLcommentRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<Comment?> CreateCommentAsync(Comment comment)
        {
            if (!await _context.Posts.AnyAsync(p => p.Id == comment.PostId))
                return null;

            if (!await _context.Users.AnyAsync(p => p.Id == comment.UserId))
                return null;

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment?> DeleteCommentAsync(Guid id)
        {
            var CommentToDelete = await _context.Comments.FirstOrDefaultAsync(p => p.Id == id);

            if (CommentToDelete == null) return null;

            _context.Comments.Remove(CommentToDelete);

            await _context.SaveChangesAsync();

            return CommentToDelete;

        }
    }
}
