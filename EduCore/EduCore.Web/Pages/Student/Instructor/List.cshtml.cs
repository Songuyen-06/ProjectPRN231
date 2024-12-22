using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EduCore.Web.Pages.Student.Instructor
{
    public class ListModel : PageModel
    {
        IInstructorService _instructorService;
        ICategoryService _categoryService;
        ICourseService _courseService;
        public ListModel(IInstructorService instructorService, ICategoryService categoryService, ICourseService courseService)
        {
            _instructorService = instructorService;
            _categoryService = categoryService;
            _courseService = courseService;
        }
        [BindProperty]
        public List<InstructorDTO> Instructors { get; set; }

        public async Task OnGetAsync(int? cateId, int? subCateId)
        {
            var userJson = HttpContext.Session.GetString("User");
            if (userJson != null)
            {
                var u = JsonConvert.DeserializeObject<UserDTO>(userJson);
                ViewData["NumberCourseCart"] = (await _courseService.GetListCourseByStudentId(u.UserId, true)).Count();
            }
            int categoryId = cateId ?? 1;
            ViewData["CateId"] = categoryId;
            ViewData["SubCateId"] = subCateId;
            Instructors = await _instructorService.GetListInstructorByFilter(categoryId, subCateId);

            ViewData["Categories"] = await _categoryService.GetListCategory(); 
            ViewData["NumberPage"] = _instructorService.GetNumberPageInstructor(Instructors.Count);
            
        }

    }
}
