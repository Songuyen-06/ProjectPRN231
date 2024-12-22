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
    internal class StudentCourseProfile : Profile

    {
        public StudentCourseProfile()
        {
            CreateMap<StudentCourse, StudentCourseDTO>().
               ForMember(dest => dest.UserId, opt => opt.MapFrom(opt => opt.UserId)).
               ForMember(dest => dest.CourseId, opt => opt.MapFrom(opt => opt.CourseId)).
                              ForMember(dest => dest.IsInCart, opt => opt.MapFrom(opt => opt.IsInCart)).
            ReverseMap();



        }

    }
}
