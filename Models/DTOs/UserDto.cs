namespace postsAPI.Models.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<CommentDto> Comments;
        public List<PostDto> Posts;
    }
}
