using postsAPI.Models.DTOs;

namespace postsAPI.Services.Auth
{
    public interface IAuthService 
    {
        public  Task<UserResponseDto> Login(string email, string password);

        public Task<UserDto> Register(CreateUserDto user);
    }
}
