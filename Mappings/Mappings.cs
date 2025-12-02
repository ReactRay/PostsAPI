using AutoMapper;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;

public class Mappings : Profile
{
    public Mappings()
    {
        // DTO → Domain
        CreateMap<CreatePostDto, Post>();
        CreateMap<CreateUserDto, ApplicationUser>();

        // ApplicationUser → UserDto
        CreateMap<ApplicationUser, UserDto>();

        // Comment → CommentDto
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

        // Post → PostDto
        CreateMap<Post, PostDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
    }
}
