﻿using AutoMapper;
using CourseDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDomain.Profiles
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