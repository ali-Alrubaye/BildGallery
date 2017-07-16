using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MapperClass;
using BusinessLayer.Models;

namespace LabTow.Areas.Admin.Controllers
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
        public ActionResult Index()
        {
            var list = UserAutomapper.FromBltoUiGetAll();




            return View((IList<UserViewModel>) list);
        }
    }
}