using AutoMapper;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.Profiles
{
    public class ReplyProfile : Profile
    {
        public ReplyProfile()
        {
            
        //CreateMap<Reply, ReplyDTO>()
        //    .ForMember(dest => dest.ReplyId, opt => opt.MapFrom(src => src.ReplyId))
        //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
        //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
        //    .ForMember(dest => dest.UserImg, opt => opt.MapFrom(src => src.User.UrlImage))
        //    .ForMember(dest => dest.NumberOfLikes, opt => opt.MapFrom(src => src.NumberOfLikes))
        //    .ForMember(dest => dest.ReplyOn, opt => opt.MapFrom(src => src.ReplyOn)).ReverseMap();
        //
        }
    }
}
