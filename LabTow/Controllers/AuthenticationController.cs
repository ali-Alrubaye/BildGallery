using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MapperClass;
using BusinessLayer.Models;


namespace LabTow.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        public UserAutomapper UserAutomapper { get; set; }
        public AuthenticationController()
        {
            UserAutomapper = new UserAutomapper();
        }

        // GET: /Account/Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }
        // GET: Authentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel model)
        {
            var user = UserAutomapper.FromBltoUiCheckUser(model);

            //if (!ModelState.IsValid) //Checks if input fields have the correct format
            //{
            //    return View(model); //Returns the view with the input values so that the user doesn't have to retype again
            //}
            if (user == null) return View();

            var checkU = user.IsAdministrator;
            if (user != null)
            {
                SetUpAuthCookie(user);
                if (checkU)
                {
                    //return RedirectToAction("Index", "Admin");
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                else
                {
                    //return RedirectToAction("Index", "User", new { area = "User" });
                    return RedirectToAction("List", "Photo");
                }
            }
            /*
                        ModelState.AddModelError("", "Invalid email or passsword");
            */
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");

            //var authenticationManager = HttpContext.GetOwinContext().Authentication;

            //authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            ////return RedirectToAction("Login");
            ////FormsAuthentication.SignOut();
            //return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string username, string password, string email)
        {
            var user = new UserViewModel
            {
                IsAdministrator = false,
                Id = new Guid(),
                UserN = username,
                Email = email,
                Pwd = password
            };

            UserAutomapper.FromBltoUiInser(user);


            return RedirectToAction("Index", "Home");
        }
        private void SetUpAuthCookie(UserViewModel user)
        {

            var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, user.UserN),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.IsAdministrator ? "Admin" : "User")
                        },
                           "ApplicationCookie");

            var result = Request.GetOwinContext();
            var authManager = result.Authentication;

            authManager.SignIn(identity);
        }

    }
}