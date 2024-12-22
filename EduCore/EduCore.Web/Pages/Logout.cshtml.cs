using System.Threading.Tasks;
using CourseDomain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CourseWeb.Pages.Home
{
    public class LogoutModel : PageModel
    {
        [TempData]
        public string LogoutError { get; set; }

        public IActionResult OnGet()
        {
            var userJson = HttpContext.Session.GetString("User");
            if (!string.IsNullOrEmpty(userJson))
            {
                try
                {
                    var user = JsonConvert.DeserializeObject<UserDTO>(userJson);
                    HttpContext.Session.Clear();
                    switch (user.RoleId)
                    {
                        case 1:
                            return RedirectToPage("/Student/Index");
                        case 3:
                            return RedirectToPage("/Home/LoginAndSignup");
                        case 2:
                            return RedirectToPage("/Instructor/Index");
                        default:
                            return RedirectToPage("/Home/LoginAndSignup");
                    }
                }
                catch (JsonException)
                {
                    LogoutError = "Error during logout. Please try again.";
                    return RedirectToPage("/Home/LoginAndSignup");
                }
            }
            else
            {
                LogoutError = "No user is logged in.";
                return RedirectToPage("/Home/LoginAndSignup");
            }
        }
    }
}
