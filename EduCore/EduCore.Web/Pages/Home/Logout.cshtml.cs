using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduCore.Web.Pages.Home
{
    public class LogoutModel : PageModel
    {
        [TempData]
        public string LogoutError { get; set; }

        public async Task<IActionResult> OnGetLogout()
        {
            try
            {
                if (HttpContext.Request.Cookies["User"] != null)
                {
                    HttpContext.Response.Cookies.Append("User", "", new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(-1),
                        HttpOnly = true,
                        Secure = true 
                    });
                }
                else
                {
                    HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }

            }
            catch (Exception ex) 
            {
                LogoutError = "Error during logout. Please try again.";
                return Page();
            }

            return Redirect("/Student");
        }
    }
}
