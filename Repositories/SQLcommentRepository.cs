using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using postsAPI.Data;
using postsAPI.Models.Domain;
using System.Security.Claims;

namespace postsAPI.Repositories
{
    public class SQLcommentRepository(AppDbContext _context,UserManager<ApplicationUser> _userManager) : ICommentRepository
    {
    



        public async Task<Comment?> CreateCommentAsync(Comment comment ,ClaimsPrincipal user)
        {
            if (!await _context.Posts.AnyAsync(p => p.Id == comment.PostId))
                return null;

            if (!await _context.Users.AnyAsync(p => p.Id == comment.UserId))
                return null;

            var userId = _userManager.GetUserId(user);

            if (comment.UserId != userId) return null;

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment?> DeleteCommentAsync(Guid id ,Guid userId)
        {
            var CommentToDelete = await _context.Comments.FirstOrDefaultAsync(p => p.Id == id);

            if (CommentToDelete.UserId != userId.ToString()) return null;

            if (CommentToDelete == null) return null;

            _context.Comments.Remove(CommentToDelete);

            await _context.SaveChangesAsync();

            return CommentToDelete;

        }
    }
}
