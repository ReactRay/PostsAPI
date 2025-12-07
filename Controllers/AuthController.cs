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
    public class AuthController( IAuthService _authService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody]CreateUserDto userToCreate)
        {
            
            return Ok(await _authService.Register(userToCreate));
        }


        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody]LoginDto login)
        {
            return Ok(await _authService.Login(login));
        }
        



    }
}
