﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using System.Threading.Tasks;

namespace Gallery_UI.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public UserAutomapper UserAutomapper { get; set; }
        public AdminController()
        {
            UserAutomapper = new UserAutomapper();
        }
        [Authorize(Roles = "Admin")]
        // GET: Administration/Admin
        public async Task<ActionResult> Index()
        {
            var list = await UserAutomapper.FromBltoUiGetAll();




            return View((IList<UserViewModel>)list);
        }
    }
}