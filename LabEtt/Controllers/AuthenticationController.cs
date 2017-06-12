﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Datalager.Models;
using Microsoft.AspNet.Identity;

namespace LabEtt.Controllers
{
    public class AuthenticationController : Controller
    {

        List<AppUser> ListUser = new List<AppUser>
        {
            new AppUser { IsAdministrator = true,Id = new Guid(), Email = "Admin@admin.com", UserN = "Admin", Pwd = "Admin@123"},
            new AppUser { IsAdministrator = false,Id = new Guid(), Email = "User1@user.com", UserN = "User1", Pwd = "Admin@123"}
        };
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        // GET: Authentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            var user = ListUser.FirstOrDefault(x => x.UserN == username && x.Pwd == password);

            if (user == null) return View();

            var checkU = user.IsAdministrator;
            if (user != null)
            {
                SetUpAuthCookie(user);
                if (checkU)
                {
                    //return RedirectToAction("Index", "Admin");
                    return RedirectToAction("Index", "Admin", new { area = "Administration" });
                }
                else
                {
                    return RedirectToAction("Index", "User", new { area = "User" });
                }
            }
            //ModelState.AddModelError("", "Invalid email or passsword");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;

            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            //return RedirectToAction("Login");
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string username, string password, string email)
        {
            var user = new AppUser
            {
                IsAdministrator = false,
                Id = new Guid(),
                UserN = username,
                Email = email,
                Pwd = password
            };

            ListUser.Add(user);

        
            return RedirectToAction("Index", "Home");
        }
        private void SetUpAuthCookie(AppUser user)
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