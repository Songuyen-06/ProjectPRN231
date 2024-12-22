using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace EduCore.Web.Pages.Admin.Teacher
{
    public class ListModel : PageModel
    {

        public IInstructorService _instructorService;
        public IUserService _userService;
        public IHubContext<ServerHub> _hubContext;
        public ICategoryService _categoryService;

        public ListModel(IInstructorService instructorService, IUserService userService, IHubContext<ServerHub> hubContext, ICategoryService categoryService)
        {
            _instructorService = instructorService;
            _userService = userService;
            _hubContext = hubContext;
            _categoryService = categoryService;
        }

        public List<InstructorDTO> Instructors { get; set; }

        [BindProperty(SupportsGet = true)]
        public int InstructorId { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsActive { get; set; }

        public List<CategoryDTO> CateList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SubCategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Rating { get; set; }
        
        
        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }



        [BindProperty(SupportsGet = true)]
        public string? SortBy { get; set; }

        public async Task<IActionResult> OnGet(string? searchInfo)
        {
            if (IsActive != null)
            {
                if (_userService.UpdateStatusUser(new UserStatusDTO { UserId = InstructorId, IsActive = !IsActive }).Result == 1)
                {

                    _hubContext.Clients.All.SendAsync("LoadAll", InstructorId, IsActive ? "disactive" : "active");
                }

            }

            Instructors = !string.IsNullOrEmpty(searchInfo) ? await _instructorService.GetListInstructor(searchInfo) :
                ( CategoryId != null  || SubCategoryId!=null || Rating!=null || Status!=null)? await _instructorService.GetListInstructorByFilter(CategoryId, SubCategoryId, Rating,Status) :
                await _instructorService.GetListInstructor();

            Instructors = await _instructorService.SortInstructorList(SortBy?? "monthRevenue", Instructors);

            CateList = await _categoryService.GetListCategory();
            return Page();

        }
    }
}
