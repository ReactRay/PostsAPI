using Microsoft.EntityFrameworkCore;
using postsAPI.Data;
using postsAPI.Models.Domain;

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

        public async Task<List<Post>> getAllAsync()
        {
            var posts = await context.Posts.Include(p => p.User).Include(p => p.Comments).ToListAsync();
            return posts;
        }
    }
}
