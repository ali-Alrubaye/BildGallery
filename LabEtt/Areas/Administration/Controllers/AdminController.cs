using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Datalager.Models;
using Datalager.Repositories;

namespace LabEtt.Areas.Administration.Controllers
{
    public class AdminController : Controller
    {
        public PhotoRepository PhotoRepository { get; set; }
        public AdminController()
        {
            PhotoRepository = new PhotoRepository();
        }
        [Authorize(Roles = "Admin")]
        // GET: Administration/Admin
        public ActionResult Index()
        {
           var list =  PhotoRepository.Users;
           
           
            

            return View(list);
        }
    }
}