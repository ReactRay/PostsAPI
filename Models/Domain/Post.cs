namespace postsAPI.Models.Domain
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public string Body { get; set; }


        //navigation
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
