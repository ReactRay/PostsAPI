using postsAPI.Models.Domain;

namespace postsAPI.Repositories
{
    public interface IAuthRepository
    {

        public Task<ApplicationUser> createUserAsync(ApplicationUser user);
        public Task<List<ApplicationUser>> getAllUsersAsync();
    }
}
