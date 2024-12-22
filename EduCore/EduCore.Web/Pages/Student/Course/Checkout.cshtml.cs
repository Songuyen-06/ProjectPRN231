using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EduCore.Web.Pages.Student.Course
{
    public class CheckoutModel : PageModel
    {
        public ICheckoutService _checkoutService;
        public ICourseService _courseService;
        public IVnPayService _vnPayService { get; set; }
        public IEnrollmentService _enrollmentService { get; set; }
        public CheckoutModel(IVnPayService vnPayService, ICourseService courseService, ICheckoutService checkoutService, IEnrollmentService enrollmentService)
        {
            _vnPayService = vnPayService;
            _courseService = courseService;
            _checkoutService = checkoutService;
            _enrollmentService = enrollmentService;
        }

        [BindProperty]
        public CheckoutDTO? Checkout { get; set; } = new CheckoutDTO();
        public CourseDetailDTO Course { get; set; } = new CourseDetailDTO();

        public UserDTO? Student { get; set; }=new UserDTO();

        public async Task OnGet(int? courseId)
        {


            Course = _courseService.GetCourseDetailByCourseId(courseId ?? (int)TempData.Peek("CourseId")).Result;
            if (Course != null)
            {
                TempData["CourseId"] = Course.CourseId;
            }
        }
        public async Task<IActionResult> OnPostPayment()
        {

            if (Checkout.PaymentMethod == "VNPay")
            {

                return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, Checkout));
            }
            else
            {
                return Page();

            }
        }



        public async Task<IActionResult> OnGetPaymentCallBack()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);

            if (response == null || response.VnPayResponseCode != "00")
            {
                TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayResponseCode}";

            }
            else
            {

                response.CourseId = (int)TempData.Peek("CourseId");
                response.StudentId = (int)TempData.Peek("StudentId");
                _checkoutService.AddCheckout(response);
                _enrollmentService.AddEnrollment(new
                    EnrollmentDTO
                {
                    StudentId = response.StudentId,
                    CourseId = response.CourseId,
                    EnrollmentDate = response.PaymentDate
                });
                Checkout = response;
                Course = _courseService.GetCourseDetailByCourseId((int)TempData.Peek("CourseId")).Result;
                TempData["Message"] = $"Thanh toán VNPay thành công";
            }
            return Page();
        }

    }
}
