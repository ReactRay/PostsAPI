using AutoMapper;
using Microsoft.AspNetCore.Identity;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;
using postsAPI.Repositories;
using System.Security.Claims;

namespace postsAPI.Services.Posts
{
    public class PostService(IMapper _mapper, IPostRepository _postRepo,
        UserManager<ApplicationUser> _userManager) : IPostService
    {
        public async Task<PostDto> createPostAsync(CreatePostDto dto ,ClaimsPrincipal user)
        {

            var userId =  _userManager.GetUserId(user);

            if (userId == null)
                throw new UnauthorizedAccessException("User not authenticated");

            var domainPost = _mapper.Map<Post>(dto);

            domainPost.UserId = userId;

            domainPost.User = await _userManager.FindByIdAsync(userId);
         


            domainPost = await _postRepo.createPostAsync(domainPost);

           return _mapper.Map<PostDto>(domainPost);

        }
    }
}
