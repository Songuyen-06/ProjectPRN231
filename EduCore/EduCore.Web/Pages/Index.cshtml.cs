using CourseDomain.DTOs;
using CourseWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EduCore.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginAndSignupModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserDTO User { get; set; }

        [TempData]
        public string LoginError { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return Page();
            }
            return RedirectToPage("/Home");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userService.GetUserByEmailAndPassword(User);

            if (user != null)
            {
                var userJson = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("User", userJson);

                switch (user.RoleId)
                {
                    case 1: // Student
                        return RedirectToPage("/Student/Index");
                    case 3: // Admin
                        return RedirectToPage("/Admin/Index");
                    case 2: // Instructor
                        return RedirectToPage("/Instructor/Index");
                    default:
                        LoginError = "Invalid role!";
                        return Page();
                }
            }
            else
            {
                LoginError = "Invalid email or password!";
                return Page();
            }
        }


        public async Task<IActionResult> OnPostSignup()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userService.GetUserByEmailAndPassword(User);

            if (user != null)
            {
               
                LoginError = "User Exits ,Please login";
                return Page();
            }
            else
            {
                User.RoleId = 1;
               _userService.CreateUser(User);
                var userJson = JsonConvert.SerializeObject(User);
                HttpContext.Session.SetString("User", userJson);
                return Redirect("/Student");
            }
        }

        
    }
}
