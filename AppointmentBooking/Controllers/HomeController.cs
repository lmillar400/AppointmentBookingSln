using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using AppointmentBooking.Repository;
using AppointmentBooking.Helpers;
using AppointmentBooking.Models;

namespace AppointmentBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyHelper _cryptographyHelper;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, ICryptographyHelper cryptographyHelper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _cryptographyHelper = cryptographyHelper;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if(HttpContext != null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Session.Clear();
            }
            
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                return LocalRedirect("/Home/Login?error=1");
            }

            //Check the user name and password  
            var user = _userRepository.GetUserByUserName(userName);
            if (user != null)
            {
                //Check Password
                bool isPasswordValid = _cryptographyHelper.AreEqual(password, user.PasswordHash, user.PasswordSalt);
                if (isPasswordValid)
                {
                    //Create the identity for the user  
                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.UserRoleId.ToString())
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    HttpContext.Session.SetInt32("RoleId", user.UserRoleId);
                    HttpContext.Session.SetInt32("UserId", user.UserId);

                    return RedirectToAction("Index", "Home");
                }
            }

            return LocalRedirect("/Home/Login?error=1");
        }

        [Authorize]
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [Authorize]
        public IActionResult UnAuthorized()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
