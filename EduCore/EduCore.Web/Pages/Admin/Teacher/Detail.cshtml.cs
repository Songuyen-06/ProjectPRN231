
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;

namespace EduCore.Web.Pages.Admin.Teacher
{
    public class DetailModel : PageModel
    {
        public IInstructorService _instructorService;
        public ICourseService _courseService;
        public IEnrollmentService _enrollmentService;
        public IUserService _userService;

        public DetailModel(IInstructorService instructorService, ICourseService courseService, IEnrollmentService enrollment, IUserService userService)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _enrollmentService = enrollment;
            _userService = userService;
        }
        public List<RevenueDTO>? MonthsRevenueOfPreviousYear { get; set; }
        public List<RevenueDTO>? MonthsRevenueOfCurrentYear { get; set; }
        public InstructorDetailDTO Instructor { get; set; }
        public List<EnrollmentDetailDTO> EnrollmentList { get; set; }

        [BindProperty]
        public UserDTO? UpdatedUser { get; set; }=new UserDTO();

        public async void OnGet(int instructorId = 4,int revenueSharePercentage=50)
        {
            MonthsRevenueOfCurrentYear = await _enrollmentService.GetMonthlyRevenueByInstructorId(revenueSharePercentage, instructorId, DateTime.Now.Year);
            MonthsRevenueOfPreviousYear = await _enrollmentService.GetMonthlyRevenueByInstructorId(revenueSharePercentage, instructorId, DateTime.Now.Year - 1);
            Instructor = await _instructorService.GetInstructorDetailById(instructorId);
            EnrollmentList = _enrollmentService.GetListEnrollment().Result.Where(en => en.CourseInstructorId == instructorId).ToList();



        }
        public async Task<IActionResult> OnPost()
        {

            if (_userService.UpdateUser(UpdatedUser).Result == 1)
            {
                TempData["Messenger"] = $"{UpdatedUser.FullName} with ID={UpdatedUser.UserId} update successfully!";
            }
            else
            {
                TempData["Messenger"] = "Update fail";
            }
            return RedirectToPage("./Detail", new { instructorId = UpdatedUser.UserId });
        }
    }
}
