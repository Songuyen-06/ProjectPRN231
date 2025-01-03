using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace EduCore.Web.Pages.Student.Course
{
    public class ListModel : PageModel
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;

        [BindProperty]
        //public List<CourseDetailDTO> Courses { get; set; }
        public List<CategoryDTO> Categories { get; set; }

        [BindProperty]
        public List<SubCategoryDTO> SubCategories { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CateId { get; set; }


        [BindProperty(SupportsGet = true)]
        public int? SubCateId { get; set; }


        [BindProperty(SupportsGet = true)]
        public int? PageIndex { get; set; }=1;

        [BindProperty(SupportsGet = true)]
        public string? Levels { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Price { get; set; }

        public  List<CourseDTO> EnrolledCourses { get; set; }   

        [BindProperty(SupportsGet = true)]
        public int? Rating { get; set; }

        public bool IsFilterByCompletedCourses { get; set; }=false;


        public ListModel(ICourseService courseService, ICategoryService categoryService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
        }

        public async Task OnGetAsync()
        {
            SortBy ??= "Popular";
            CateId ??= 1;
            PageIndex ??= 1;
            Levels ??= "All";
            var userJson = HttpContext.Session.GetString("User");
            if (userJson != null)
            {
                var u = JsonConvert.DeserializeObject<UserDTO>(userJson);
                ViewData["NumberCourseCart"] = (await _courseService.GetListCourseByStudentId(u.UserId, true)).Count();
            }
       
            Categories = await _categoryService.GetListCategory();
            SubCategories = Categories.FirstOrDefault(c => c.CategoryId.Equals(CateId)).SubCategories;

        }
        public async Task OnGetEnrollment(int studentId)
        {
            EnrolledCourses = await _courseService.GetEnrolledCourseListByStudentId(studentId);
        }


    }
}