namespace postsAPI.Models.Domain
{
    public class Comment
    {
        public Guid Id  { get; set; } = Guid.NewGuid();

        public string CommentBody { get; set; }


        //navigation

        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid PostId { get; set; }

        public Post Post { get; set; }
    }
}
