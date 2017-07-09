using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MapperClass;
using BusinessLayer.Models;

namespace LabTow.Controllers
{
    public class CommentController : Controller
    {
        //private AlbumAutomapper AlbumAutomapper { get; set; }
        //private PhotoAutomapper PhotoAutomapper { get; set; }
        private CommentAutomapper CommentAutomapper { get; set; }

        public CommentController()
        {
            CommentAutomapper = new CommentAutomapper();
        }
        // GET: Comment
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            var p = CommentAutomapper.FromBltoUiGetAll().OrderBy(x => x.Date);
            return PartialView("_list", p);
        }
        //
        // GET: /Comment/Create
        [HttpGet]
        public PartialViewResult Create()
        {

            return PartialView("_CreateComment");
        }

        //
        // POST: /Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel com)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    var identity = (ClaimsIdentity)User.Identity;
            //    var usId = CommentAutomapper.FromBltoUiGetById(com.UserId);
            //    //int? userID = int.Parse(Helpers.GetSid(identity));
            //    if (usId != null)
            //    {
            //        com.Date = DateTime.Now;
            //        com.UserId = Guid.NewGuid();

            //        var entity = EntityModelMapper.ModelToEntity(model);
            //        repo.AddOrUpdate(entity);
            //    }
            //    return RedirectToAction("Index", "Gallery");
            //}
            return Json(new { status = 1, Message = "Added Comment Success" });
        }
    }
}