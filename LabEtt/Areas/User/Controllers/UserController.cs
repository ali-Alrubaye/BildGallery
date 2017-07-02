﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabEtt.Areas.User.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "User")]
        // GET: User/User
        public ActionResult Index()
        {
            return View();
        }
    }
}