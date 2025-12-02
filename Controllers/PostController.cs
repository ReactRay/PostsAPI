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
            var domainPosts = await repo.getAllAsync();
            var postsDto = mapper.Map<List<PostDto>>(domainPosts);
            return Ok(postsDto);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPostById(string id)
        {
            var domainPost = await repo.getPostById(id);
            if (domainPost == null) return NotFound("not found");
            var postDto = mapper.Map<PostDto>(domainPost);
            return Ok(postDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto post)
        {
            var domainPost = mapper.Map<Post>(post);
            await repo.createPostAsync(domainPost);
            return Ok($"post created {domainPost}");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDto post,string id)
        {
            var domainPost = mapper.Map<Post>(post);

            domainPost = await repo.updatePost(domainPost, id);
            if(domainPost == null) return NotFound("not found");
            var postDto = mapper.Map<PostDto>(domainPost);
            return Ok(postDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            var deletedPost = await repo.deletePost(id);

            if (deletedPost == null)
                return NotFound("Post not found");

            var postDto = mapper.Map<PostDto>(deletedPost);

            return Ok(postDto);
        }


    }
}
