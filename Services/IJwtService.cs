using postsAPI.Models.Domain;

namespace postsAPI.Services
{
    public interface IJwtService
    {

        Task<String> CreateTokenAsync(ApplicationUser user);
    }
}
