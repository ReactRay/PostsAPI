namespace postsAPI.Models.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string CommentBody { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
