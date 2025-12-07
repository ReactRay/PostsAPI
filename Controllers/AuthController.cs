using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;
using postsAPI.Repositories;
using postsAPI.Services.Auth;

namespace postsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMapper _mapper, IAuthService _authService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> register(CreateUserDto userToCreate)
        {
            return Ok(await _authService.Register(userToCreate));
        }

        



    }
}
