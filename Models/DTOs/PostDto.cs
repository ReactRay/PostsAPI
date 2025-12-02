namespace postsAPI.Models.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        // User info
        public string UserId { get; set; }
        public string UserName { get; set; }

        // Comment info
        public List<CommentDto> Comments { get; set; }
    }
}
