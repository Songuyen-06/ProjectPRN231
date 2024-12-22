using EduCore.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EduCore.Web.Pages.Teacher
{
    public class IndexModel : PageModel
    {


        public async Task<IActionResult> OnGet()
        {
            //string userJson = HttpContext.Request.Cookies["User"] ??
            //          HttpContext?.Session?.GetString("User");
            //if (userJson != null)
            //{
            //    User = JsonConvert.DeserializeObject<UserDTO>(userJson);
            //}
            return Page();
        }
    }
}
