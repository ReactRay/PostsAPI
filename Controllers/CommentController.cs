using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;
using postsAPI.Repositories;

namespace postsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICommentRepository repo;

        public CommentController(IMapper mapper ,ICommentRepository repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }



        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto comment)
        {
            var domainComment = mapper.Map<Comment>(comment);
            
            domainComment = await repo.CreateCommentAsync(domainComment);

            if (domainComment == null) return BadRequest("something went wrong");

            return Ok(mapper.Map<CommentDto>(domainComment));
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var commentToDelete = await repo.DeleteCommentAsync(id);

            if (commentToDelete == null) return NotFound("comment not found");

            return Ok(mapper.Map<CommentDto>(commentToDelete));

        }


    }





}
