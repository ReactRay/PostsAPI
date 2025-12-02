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
    }
}
