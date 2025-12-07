using AutoMapper;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;
using postsAPI.Repositories;
using System.Security.Claims;

namespace postsAPI.Services.Comments
{
    public class CommentService(ICommentRepository _commentRepo,IMapper _mapper) : ICommentService
    {
        public async Task<CommentDto> createComment(CreateCommentDto dto, ClaimsPrincipal user)
        {
            var domainComment = _mapper.Map<Comment>(dto);

            var result = await _commentRepo.CreateCommentAsync(domainComment,user);

            if (result == null) throw new Exception("something went wrong");

            return _mapper.Map<CommentDto>(result);
        }
    }
}
