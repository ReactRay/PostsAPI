namespace postsAPI.Models.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<PostDto> Posts { get; set; } = new();    
        public List<CommentDto> Comments { get; set; } = new(); 
    }
}
