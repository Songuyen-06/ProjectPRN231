using Microsoft.AspNetCore.Mvc;
using EduCore.Domain.Models;
using EduCore.Domain.DTOs;
using EduCore.Web.Services;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace EduCore.Web.Pages.Shared.Components.CourseList
{
    [ViewComponent]
    public class CourseList : ViewComponent

    {
        private readonly ICourseService courseService;
        private readonly ICompletionStatusService completionStatusService ;

        public CourseList(ICourseService _courseService,ICompletionStatusService _completionStatusService)
        {
            courseService = _courseService;
            completionStatusService = _completionStatusService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int cateId,int? subCateId, int pageIndex, List<CourseDTO> courseList, int? rating, string? levels, string? price,string sortby,bool  isCarousel=false)
        {
            string userJson = HttpContext.Request.Cookies["User"] ?? HttpContext?.Session?.GetString("User");
            UserDTO? student = !string.IsNullOrEmpty(userJson) ? JsonConvert.DeserializeObject<UserDTO>(userJson) : null;

            courseList ??= await courseService.GetListCourseByFilter(cateId,subCateId, levels, rating, price, sortby);
            ViewData["Student"] = student;
            TempData["FilterResult"]=courseList.Count();
            TempData["TotalPage"] = courseService.GetTotalPageCourse(courseList.Count(), 8);
            ViewData["IsCarousel"] = isCarousel;
            //ViewData["CompletionStatusList"] = completionStatusService.GetCompletionStatusListByStudentId(student.UserId);

            courseList = courseService.GetListCourseByPagging(courseList, pageIndex, 8);
            return View(courseList);

        }
    }
}
