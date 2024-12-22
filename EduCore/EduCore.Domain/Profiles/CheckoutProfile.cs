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
    public  class CheckoutProfile:Profile
    {
        public CheckoutProfile()
        {
            CreateMap<StudentCheckout, CheckoutDTO>()
             .ForMember(dest => dest.CheckoutId, opt => opt.MapFrom(src => src.CheckoutId))
             .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
             .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.FullName))
             .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
             .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
             .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate))
             .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
             .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Title))
             .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
             
             .ReverseMap();
        }
    }
}
