namespace postsAPI.Models.DTOs
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
    }
}
