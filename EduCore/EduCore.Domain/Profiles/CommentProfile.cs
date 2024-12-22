using AutoMapper;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;

namespace EduCore.Domain.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>()
             .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
             .ForMember(dest => dest.UserImg, opt => opt.MapFrom(src => src.User.UrlImage))
             .ForMember(dest => dest.CommentOn, opt => opt.MapFrom(src => src.CommentOn))
             .ForMember(dest => dest.Replies, opt => opt.MapFrom(src => src.InverseReply)).
             ReverseMap();

            CreateMap<Comment, AddedCommentDTO>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.LectureId, opt => opt.MapFrom(src => src.LectureId))
            .ForMember(dest => dest.ReplyId, opt => opt.MapFrom(src => src.ReplyId)).ReverseMap();
        }
    }
}
