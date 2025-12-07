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
            var userId = _userManager.GetUserId(user);
            if (userId == null)
                throw new UnauthorizedAccessException();

            var domainPost = _mapper.Map<Post>(dto);
            domainPost.UserId = userId;

            domainPost = await _postRepo.createPostAsync(domainPost);
            return _mapper.Map<PostDto>(domainPost);


        }

        public async Task<PostDto> deletePost(Guid id ,ClaimsPrincipal user)
        {

            var userId = _userManager.GetUserId(user);

            var postToDelete = await _postRepo.deletePostAsync(id.ToString() ,userId);

            if (postToDelete == null) throw new KeyNotFoundException("post not found");

            return _mapper.Map<PostDto>(postToDelete);
        }

        public async Task<List<PostDto>> getAllPostsAsync()
        {
            var posts = await _postRepo.getAllAsync();

            return _mapper.Map<List<PostDto>>(posts);

          
        }

        public async Task<PostDto> getPostById(string id)
        {
            var domainPost = await _postRepo.getPostById(id);

            if (domainPost == null) throw new KeyNotFoundException("Post not found");


            return _mapper.Map<PostDto>(domainPost);
        }

        public async Task<PostDto> UpdatePostAsync(UpdatePostDto updates , string id, ClaimsPrincipal user)
        {
            var userId = _userManager.GetUserId(user).ToString();
            if (userId == null)
                throw new UnauthorizedAccessException("User not authenticated");

            var post = await _postRepo.updatePostAsync(updates,id,userId);

            if (post == null)
                throw new UnauthorizedAccessException("Not owner or post not found");

            return _mapper.Map<PostDto>(post);
        }


    }
}
