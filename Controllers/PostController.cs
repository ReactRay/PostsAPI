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

    }
}
