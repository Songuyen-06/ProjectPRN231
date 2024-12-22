using EduCore.Domain.DTOs;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EduCore.Web.Pages.Student.Cart
{
    public class ListModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;

        public ListModel(ICategoryService categoryService, ICourseService courseService)
        {
            _categoryService = categoryService;
            _courseService = courseService;
        }

        [BindProperty]
        public List<CourseDTO> Courses { get; set; }
        public async Task  OnGetAsync()
        {
            var userJson = HttpContext.Session.GetString("User");
            if (userJson != null )
            {
                
                var u = JsonConvert.DeserializeObject<UserDTO>(userJson);
                if(u.RoleId == 1)
                {
                  Courses = await _courseService.GetListCourseByStudentId(u.UserId,true);
                    ViewData["NumberCourseCart"] = Courses.Count();

                }

            }

            ViewData["Categories"] = await _categoryService.GetListCategory();
        }
    }
}
