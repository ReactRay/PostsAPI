using AutoMapper;
using Microsoft.AspNetCore.Identity;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;
using postsAPI.Repositories;
using System.Security.Claims;

namespace postsAPI.Services.Comments
{
    public class CommentService(ICommentRepository _commentRepo,IMapper _mapper,UserManager<ApplicationUser> _userManger) : ICommentService
    {
        public async Task<CommentDto> createComment(CreateCommentDto dto, ClaimsPrincipal user)
        {
            var domainComment = _mapper.Map<Comment>(dto);

            var result = await _commentRepo.CreateCommentAsync(domainComment,user);

            if (result == null) throw new Exception("something went wrong");

            return _mapper.Map<CommentDto>(result);
        }

        public async Task<CommentDto> deleteCommentAsync(Guid id, ClaimsPrincipal user)
        {
            var userId = _userManger.GetUserId(user);
            var domainComment = await _commentRepo.DeleteCommentAsync(id,Guid.Parse( userId));

            if (domainComment == null) throw new Exception("something went wrong");

            return _mapper.Map<CommentDto>(domainComment);
        }
    }
}
