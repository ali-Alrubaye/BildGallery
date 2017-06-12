using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalager.Models;
using Datalager.Repositories;

namespace LabEtt.Controllers
{
    public class HomeController : Controller
    {
        public PhotoRepository PhotoRepository { get; set; }
        public HomeController()
        {
            PhotoRepository = new PhotoRepository();
        }
        // GET: Home
        public ActionResult Index()
        {
            var ctx = PhotoRepository.Photos;
            
            return View(ctx);
        }
      
    }
}