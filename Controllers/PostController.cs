using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;
using postsAPI.Permissions;
using postsAPI.Repositories;
using postsAPI.Services.Posts;

namespace postsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 

    public class PostController(IPostService _postService) : ControllerBase
    {

        [HttpPost]
        [HasPermission(AppPermissions.CreatePost)]
        public async Task<IActionResult> createPost([FromBody]CreatePostDto dto)
        {

            return Ok(await _postService.createPostAsync(dto, User));
        }

        [HttpGet]
        [HasPermission(AppPermissions.GetPost)]
        public async Task<IActionResult> getAllposts()
        {
            return Ok(await _postService.getAllPostsAsync());
        }

        [HttpGet("{id}")]
        [HasPermission(AppPermissions.GetPost)]
        public async Task<IActionResult> getPostById(string id)
        {
            return Ok(await _postService.getPostById(id));
        }

        [HttpPut("{id}")]
        [HasPermission(AppPermissions.EditPost)]
        public async Task<IActionResult> updatePost([FromBody] UpdatePostDto updates, string id)
        {
            return Ok(await _postService.UpdatePostAsync(updates,id,User));
        }

        [HttpDelete("{id:Guid}")]
        [HasPermission(AppPermissions.DeletePost)]
        public async Task<IActionResult> deletePost(Guid id)
        {
            return Ok(_postService.deletePost(id, User));
        }

    }
}
