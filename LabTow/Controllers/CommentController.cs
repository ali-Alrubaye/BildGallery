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
    [Authorize]
    public class CommentController : Controller
    {
        private AlbumAutomapper AlbumAutomapper { get; set; }
        //private PhotoAutomapper PhotoAutomapper { get; set; }
        private CommentAutomapper CommentAutomapper { get; set; }

        public CommentController()
        {
            AlbumAutomapper = new AlbumAutomapper();
            CommentAutomapper = new CommentAutomapper();
        }
        [AllowAnonymous]
        // GET: Comment
        public ActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult List()
        {
            var p = CommentAutomapper.FromBltoUiGetAll().OrderBy(x => x.Date);
            return PartialView("_list", p);
        }
        //
        // GET: /Comment/Create
        [HttpGet]
        public PartialViewResult CreateComment(Guid id)
        {
            var newComm = new CommentViewModel();
            var alb = AlbumAutomapper.FromBltoUiGetById(id);
            newComm.AlbumId = id;
            newComm.AlbumCView = alb;
            return PartialView("_CreateComment", newComm);
        }

        //
        // POST: /Comment/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateComment(CommentViewModel com)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            var identity = (ClaimsIdentity)User.Identity;
            var usId = CommentAutomapper.FromBltoUiGetById(com.UserId);
            
            //if (usId != null)
            //{
            com.Date = DateTime.Now;
            com.UserId = Guid.NewGuid();
            com.AlbumId = com.AlbumId;

            CommentAutomapper.FromBltoUiInser(com);
            return Json(new { status = 1, Message = "Added Comment Success" });
            //}

            //}
            //return Json(new { status = 1, Message = "Couldn't add comment" });
        }
        [HttpPost]
        public ActionResult Delete(Guid commentID)
        {
            if (User.Identity.IsAuthenticated)
            {

                    var commentToRemove = CommentAutomapper.FromBltoUiGetById(commentID);
                    if (commentToRemove != null)
                    {
                    CommentAutomapper.FromBltoUiDeleteAsync(commentID);
                    }
                    return Content("Comment was removed.");
                }

            
            return Content("Couldn't remove comment.");
        }
    }
}