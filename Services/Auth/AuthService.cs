using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;
using postsAPI.Services.Jwt;

namespace postsAPI.Services.Auth
{
    public class AuthService(UserManager<ApplicationUser> _UserManager,RoleManager<IdentityRole> _RoleManager
        ,IJwtService _JwtService,IMapper _mapper)
        : IAuthService
    {
       



        public async Task<UserResponseDto> Login(string email, string password)
        {
            var user = await _UserManager.FindByEmailAsync(email);

            if (user == null || !await _UserManager.CheckPasswordAsync(user, password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var token = await _JwtService.CreateTokenAsync(user);

            var userDto = _mapper.Map<UserDto>(user);

            return new UserResponseDto
            {
                Token = token,
                User = userDto
            };

        }

        public async Task<UserDto> Register(CreateUserDto dto)
        {
            if (await _UserManager.FindByEmailAsync(dto.Email) != null)
                throw new InvalidOperationException("Email already exists");

            var user = _mapper.Map<ApplicationUser>(dto);
            user.UserName = dto.Email;

            var result = await _UserManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ",
                    result.Errors.Select(e => e.Description)));

            if (!await _RoleManager.RoleExistsAsync(dto.Role))
                throw new Exception("role does not exist");

            await _UserManager.AddToRoleAsync(user, dto.Role);

            return _mapper.Map<UserDto>(user);
        }

    }
}
