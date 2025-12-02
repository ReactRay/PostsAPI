using Microsoft.EntityFrameworkCore;
using postsAPI.Data;
using postsAPI.Models.Domain;

namespace postsAPI.Repositories
{
    public class SQLauthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public SQLauthRepository(AppDbContext context)
        {
           _context = context;
        }
        public async Task<ApplicationUser> createUserAsync(ApplicationUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<List<ApplicationUser>> getAllUsersAsync()
        {
            var users = await _context.Users.Include(p => p.Comments).Include(p => p.Posts).ToListAsync();

            return users;
        }
    }
}
