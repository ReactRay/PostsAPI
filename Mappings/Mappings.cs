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
        CreateMap<UpdatePostDto, Post>();

        // ApplicationUser → UserDto
        CreateMap<ApplicationUser, UserDto>()
    .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts))
    .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));


        // Comment → CommentDto
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

        // Post → PostDto
        CreateMap<Post, PostDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
    }
}
