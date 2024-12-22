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
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(opt => opt.UserId))
                             .ForMember(dest => dest.FullName, opt => opt.MapFrom(opt => opt.FullName))
                          .ForMember(dest => dest.Email, opt => opt.MapFrom(opt => opt.Email))
                          .ForMember(dest => dest.Phone, opt => opt.MapFrom(opt => opt.Phone))
                          .ForMember(dest => dest.Password, opt => opt.MapFrom(opt => opt.Password))
                          .ForMember(dest => dest.Bio, opt => opt.MapFrom(opt=> opt.Bio))
                          .ForMember(dest => dest.UrlImage, opt => opt.MapFrom(opt => opt.UrlImage))
                          .ForMember(dest => dest.RoleId, opt => opt.MapFrom(opt => opt.RoleId))
                          .ForMember(dest => dest.IsActive, opt => opt.MapFrom(opt => opt.IsActive))
                          .ReverseMap();

        }
    }
}
