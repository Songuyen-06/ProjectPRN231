using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDTO>()
            //.ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            //.ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            //.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.SubCategory.CategoryId))
            //.ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId))
            //.ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
            //.ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //.ForMember(dest => dest.Sale, opt => opt.MapFrom(src => src.Sale))
            //.ForMember(dest => dest.PriceAfterSale, opt => opt.MapFrom(src => src.Price - (src.Price * src.Sale / 100m)))
            //.ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId))
            //.ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.FullName))
            //.ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
            //.ForMember(dest => dest.RatingNumber, opt => opt.MapFrom(src => src.Reviews.Count()))
            //.ForMember(dest => dest.StudentNumber, opt => opt.MapFrom(src => src.Enrollments.Count))
            //.ForMember(dest => dest.SectionNumber, opt => opt.MapFrom(src => src.Sections.Count))
            //.ForMember(dest => dest.LectureNumber, opt => opt.MapFrom(src => src.Sections.Sum(s => s.Lectures.Count)))
            //.ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
            //.ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime))
   
      .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
      .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
      //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
      .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
      .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
      .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
      .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
      .ForMember(dest => dest.Sale, opt => opt.MapFrom(src => src.Sale))
      .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId))
      .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
     .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId))
     .ReverseMap();


        CreateMap<Course, CourseDetailDTO>()
            .IncludeBase<Course, CourseDTO>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.Sections))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
            .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents))
            .ReverseMap();

        //   .IncludeBase<Course,CourseDTO>()
        //    .ForMember(dest => dest.PriceAfterSale, opt => opt.MapFrom(src => src.Price - (src.Price * src.Sale / 100m)))
        //    .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.FullName))
        //    .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
        //    .ForMember(dest => dest.RatingNumber, opt => opt.MapFrom(src => src.Reviews.Count()))
        //    .ForMember(dest => dest.StudentNumber, opt => opt.MapFrom(src => src.Enrollments.Count))
        //    .ForMember(dest => dest.SectionNumber, opt => opt.MapFrom(src => src.Sections.Count))
        //    .ForMember(dest => dest.LectureNumber, opt => opt.MapFrom(src => src.Sections.Sum(s => s.Lectures.Count)))
        //    .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.Sections))
        //     .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))


        //.ReverseMap();

       

    }
}
