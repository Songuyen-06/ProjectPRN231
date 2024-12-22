using EduCore.Domain.DTOs;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduCore.Web.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IEnrollmentService _enrollmentService;
        public IStudentService _studentService;
        public IInstructorService _instructorService;
        public List<RevenueDTO> MonthlyRevenueOfCurrentYear;
        public List<RevenueDTO> MonthlyRevenueOfPreviousYear;
        public List<StudentDTO> Students;
        public List<InstructorDTO> Instructors;
        public List<EnrollmentDetailDTO> EnrollmentList { get; set; }



        public IndexModel(IEnrollmentService enrollmentService, IStudentService studentService, IInstructorService instructorService)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _instructorService = instructorService;
        }

        public async Task<IActionResult> OnGet(int serviceFee=10,int revenueSharePercentage=50)
        {
            MonthlyRevenueOfCurrentYear = await _enrollmentService.GetMonthlyRevenueBySoldCourses(revenueSharePercentage, DateTime.Now.Year);
            MonthlyRevenueOfPreviousYear = await _enrollmentService.GetMonthlyRevenueBySoldCourses(revenueSharePercentage, DateTime.Now.Year-1);
            Students = await _studentService.GetListStudent();
            Instructors = await _instructorService.GetListInstructor();
            EnrollmentList = _enrollmentService.GetListEnrollment().Result.Where(en => en.EnrollmentDate.Value.Year == DateTime.Now.Year).ToList(); 

            return Page();
        }
    }
}
