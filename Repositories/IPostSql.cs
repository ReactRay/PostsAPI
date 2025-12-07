using Microsoft.EntityFrameworkCore;
using postsAPI.Data;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;

namespace postsAPI.Repositories
{
    public class IPostSql : IPostRepository
    {
        private readonly AppDbContext context;

        public IPostSql(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<Post?> createPostAsync(Post post)
        {
         
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
            return post;
            
        }

        public async Task<Post?> deletePostAsync(string Id,string userId)
        {
            var domainPost = await context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            if (domainPost == null || domainPost.UserId != userId) return null;

            context.Comments.RemoveRange(domainPost.Comments);

            context.Posts.Remove(domainPost);

            await context.SaveChangesAsync();

            return domainPost;
           
        }

        public async Task<List<Post>> getAllAsync()
        {
            var posts = await context.Posts.Include(p => p.User).Include(p => p.Comments).ThenInclude(p => p.User).ToListAsync();
            return posts;
        }

        public async Task<Post?> getPostById(string Id)
        {
            var domainPost = await context.Posts.Include(p => p.User).Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            return domainPost;
        }

        public async Task<Post?> updatePostAsync(UpdatePostDto Post, string Id, string userId)
        {
            var post = await context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == Id);
            if (post == null) return null;

            if (post.UserId != userId.ToString()) return null;

            post.Title =Post.Title;
            post.Body = Post.Body;

            await context.SaveChangesAsync();
            return post;
        }

       
    }
}
