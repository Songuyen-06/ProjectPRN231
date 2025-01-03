using EduCore.Domain.DTOs;
using EduCore.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Web.Pages.Home
{
    public class LoginAndSignupModel : PageModel
    {
        private readonly IUserService _userService;
        public readonly IEmailService _emailService;

        public LoginAndSignupModel(IUserService userService, IEmailService mailService)
        {
            _userService = userService;
            _emailService = mailService;
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

                if (Request.Form["isRemeberAcc"] == true)
                {
                    HttpContext.Session.SetString("User", userJson);
                }
                else
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.MaxValue,
                        HttpOnly = true,
                        Secure = true,
                    };
                    HttpContext.Response.Cookies.Append("User", userJson, cookieOptions);

                }
                switch (user.RoleId)
                {
                    case 1: // Student
                        return RedirectToPage("/Student/Index");
                    case 3: // Admin
                        return RedirectToPage("/Admin/Index");
                    case 2: // Instructor
                        return RedirectToPage("/Teacher/Index");
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

                if (Request.Form["isRemeberAcc"] == true)
                {
                    HttpContext.Session.SetString("User", userJson);
                }
                else
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.MaxValue,
                        HttpOnly = true,
                        Secure = true,
                    };
                    HttpContext.Response.Cookies.Append("User", userJson, cookieOptions);

                }

                return Redirect("/Student");
            }
        }

        public async Task OnGetSigninGoogle()
        {
            //await HttpContext.ChallengeAsync(
            //    GoogleDefaults.AuthenticationScheme,
            //    new AuthenticationProperties
            //    {
            //        RedirectUri = Url.Page("./LoginAndSignup", "GoogleResponse", null, Request.Scheme)
            //    });
        }
        public async Task<IActionResult> OnGetGoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (result?.Succeeded == true)
            {
                var claims = result.Principal.Identities
                    .FirstOrDefault()?.Claims
                    .Select(claim => new
                    {
                        claim.Issuer,
                        claim.OriginalIssuer,
                        claim.Type,
                        claim.Value
                    }).ToList();
                var userPictureClaim = claims?.FirstOrDefault(c => c.Type == "picture");
                string userPictureUrl = userPictureClaim?.Value;

                var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(new UserDTO
                {
                    Email = email,
                    FullName = name,
                    UrlImage = userPictureUrl,
                }));


                return Redirect("/Student");
            }
            else
            {
                return RedirectToPage("/LoginAndSignup");
            }
        }


        public async Task<IActionResult> OnPostConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                return RedirectToPage("/Index");
            }

            //var user = await _emailService.FindByIdAsync(userId);
            //if (user == null)
            //{
            //    return NotFound($"No user with ID {userId} was found.");
            //}

            //var result = await _emailService.ConfirmEmailAsync(user, code);
            //Message = result.Succeeded ? "Your email has been confirmed." : "Error confirming your email.";

            return Page();


        }
    }
}