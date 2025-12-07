using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;
using postsAPI.Permissions;
using postsAPI.Repositories;
using postsAPI.Services.Comments;

namespace postsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController(ICommentService _commentService) : ControllerBase
    {



        [HttpPost]
        [HasPermission(AppPermissions.CreateComment)]
        public async Task<IActionResult> createComment([FromBody] CreateCommentDto dto)
        {
            return Ok(await _commentService.createComment(dto, User));
        }


        [HttpDelete("{id:Guid}")]
        [HasPermission(AppPermissions.DeleteComment)]
        public async Task<IActionResult> deleteComment(Guid id)
        {
            return Ok(await _commentService.deleteCommentAsync(id, User));
        }


    }





}
