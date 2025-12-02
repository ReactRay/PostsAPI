using AutoMapper;
using postsAPI.Models.Domain;
using postsAPI.Models.DTOs;

public class Mappings : Profile
{
    public Mappings()
    {

        CreateMap<CreatePostDto, Post>();
        CreateMap<CreateUserDto, ApplicationUser>();


        CreateMap<ApplicationUser, UserDto>();


        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));


        CreateMap<Post, PostDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
    }
}
