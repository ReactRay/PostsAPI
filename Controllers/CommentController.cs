using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace postsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto comment)
    {

    }



    }
