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
    public class PostController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPostRepository repo;

        public PostController(IMapper _mapper,IPostRepository _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await repo.getAllAsync();

            return Ok(posts);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto post)
        {

            var domainPost = mapper.Map<Post>(post);

            await repo.createPostAsync(domainPost);

            return Ok($"post created {domainPost}");

          
        }
    }
}
