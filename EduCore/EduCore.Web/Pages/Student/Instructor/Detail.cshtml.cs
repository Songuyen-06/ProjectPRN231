using EduCore.Domain.DTOs;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EduCore.Web.Pages.Student.Instructor
{
    public class DetailModel : PageModel
    {
        IInstructorService _instructorService;
        ICourseService _courseService;
        public ICategoryService categoryService;


        public DetailModel(IInstructorService instructorService, ICourseService courseService, ICategoryService categoryService)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            this.categoryService = categoryService;
        }
        [BindProperty]
        public InstructorDetailDTO InstructorDetail { get; set; }

        [BindProperty]
        public List<CourseDTO> RelatedCourses { get; set; }
        public async Task<IActionResult> OnGetAsync(int insId)
        {
            var userJson = HttpContext.Session.GetString("User");
            if (userJson != null)
            {
                var u = JsonConvert.DeserializeObject<UserDTO>(userJson);
                ViewData["NumberCourseCart"] = (await _courseService.GetListCourseByStudentId(u.UserId, true)).Count();
            }
            InstructorDetail = await _instructorService.GetInstructorDetailById(insId);
            RelatedCourses = await _courseService.GetListRelatedCourseBySubcates(InstructorDetail.SubCategoryDetails);
            ViewData["Categories"] = await categoryService.GetListCategory();

            return Page();
        }
    }
}
