namespace postsAPI.Models.Domain
{
    public class ApplicationUser
    {
       public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserName { get; set; }


        public string Email { get; set; }


        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
