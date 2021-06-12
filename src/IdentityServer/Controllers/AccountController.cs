using System;
using System.Threading.Tasks;
using IdentityServer.Models;
using IdentityServer4;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    public class AccountController: Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (User.IsAuthenticated())
            {
                Console.WriteLine("User is logged in");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginInputModel inputModel)
        {
 
            var props =  new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromHours(1))
                };

            // issue authentication cookie with subject ID and username
            var isuser = new IdentityServerUser(inputModel.Username)
            {

                DisplayName = inputModel.Username,
            };

            await HttpContext.SignInAsync(isuser, props);

            return Redirect("http://localhost:4200/auth-callback");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (User.IsAuthenticated())
            {
                await HttpContext.SignOutAsync();
            }

            return View("Logout");
        }
        
    }
}