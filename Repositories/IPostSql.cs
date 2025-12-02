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

        public async Task<Post?> deletePostAsync(string Id)
        {
            var domainPost = await context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            if (domainPost == null) return null;

            context.Comments.RemoveRange(domainPost.Comments);

            context.Posts.Remove(domainPost);

            await context.SaveChangesAsync();

            return domainPost;
           
        }

        public async Task<List<Post>> getAllAsync()
        {
            var posts = await context.Posts.Include(p => p.User).Include(p => p.Comments).ToListAsync();
            return posts;
        }

        public async Task<Post?> getPostById(string Id)
        {
            var post = await context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == Id);

            return post;

        }

        public async Task<Post?> updatePost(Post Post, string Id)
        {
            var postToUpdate = await context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == Id);
            if (postToUpdate == null) return null;
            postToUpdate.Title = Post.Title;
            postToUpdate.Body = Post.Body;
            await context.SaveChangesAsync();

            return postToUpdate;
        }
    }
}
