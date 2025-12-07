using Microsoft.AspNetCore.Identity;

namespace postsAPI.Models.Domain
{
    public class ApplicationUser :IdentityUser
    {
   
        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
