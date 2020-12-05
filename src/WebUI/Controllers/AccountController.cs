// Controllers/AccountController.cs

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaDanse.WebUI.Controllers
{
    public class AccountController : Controller
    {
        [Route("login")]
        public async Task Login([FromQuery(Name = "redirectUri")] string redirectUri = "/")
        {
            if (string.IsNullOrEmpty(redirectUri))
                redirectUri = "/";

            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = redirectUri });
        }

        [Route("logout")]
        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            {
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be added to the
                // **Allowed Logout URLs** settings for the app.
                RedirectUri = "/"
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}