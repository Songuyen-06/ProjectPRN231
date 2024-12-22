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
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<User, StudentDTO>()
                         .IncludeBase<User, UserDTO>()
                            .ForMember(dest => dest.NumberEnrolledCourses, opt => opt.MapFrom(opt => opt.Enrollments.Count()))
                            .ForMember(dest => dest.TuitionFee, opt => opt.MapFrom(opt => opt.Enrollments.Sum(en=>en.Course.Price-(en.Course.Price*en.Course.Sale/100) )))
                            .ReverseMap();

              }
    }
}
