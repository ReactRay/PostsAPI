namespace postsAPI.Models.DTOs
{
    public class CreateCommentDto
    {
        public string CommentBody { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
    }


}
