using postsAPI.Models.DTOs;

namespace postsAPI.Services.Auth
{
    public interface IAuthService 
    {
        public  Task<UserResponseDto> Login(LoginDto userInfo);

        public Task<UserDto> Register(CreateUserDto user);
    }
}
