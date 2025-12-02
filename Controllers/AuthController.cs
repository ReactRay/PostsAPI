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
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAuthRepository _repo;

        public AuthController(IMapper mapper ,IAuthRepository repo)
        {
            this.mapper = mapper;
            this._repo = repo;

        }


        [HttpPost]
        [Route("/register")]
        
        public async Task<IActionResult> register (CreateUserDto user)
        {
            var domainUser = mapper.Map<ApplicationUser>(user);

            domainUser = await _repo.createUserAsync(domainUser);


            return Ok(domainUser);

          
        }
    }
}
