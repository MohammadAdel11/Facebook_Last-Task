using AutoMapper;
using Facebook.Models;
using Facebook.Tables;

namespace Facebook
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostModel>()
            .ForMember(dest => dest.username, src => src.MapFrom(b => b.User.Username))
            .ForMember(dest => dest.Content, src => src.MapFrom(b => b.Content))
            .ForMember(dest => dest.CreatedAt, src => src.MapFrom(b => b.CreatedAt))
            .ForMember(dest => dest.NumberOfLikes, src => src.MapFrom(b => b.Likes.Count))
            .ForMember(dest => dest.NumberOfComments, src => src.MapFrom(b => b.Comments.Count))
            .ForMember(dest => dest.NumberOfShares, src => src.MapFrom(b => b.SharedByUsers.Count))
            .ForMember(dest => dest.Comments, src => src.MapFrom(b => b.Comments.Select(comment => comment.Content).ToList()));

            CreateMap<User, UserModel>();
        }
    }
}
