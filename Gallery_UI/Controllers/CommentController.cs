using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNet.Identity;

namespace Gallery_UI.Controllers
{
    public class CommentController : Controller
    {
        public CommentController()
        {
            AlbumAutomapper = new AlbumAutomapper();
            CommentAutomapper = new CommentAutomapper();
        }

        private AlbumAutomapper AlbumAutomapper { get; }

        //private PhotoAutomapper PhotoAutomapper { get; set; }
        private CommentAutomapper CommentAutomapper { get; }

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
            var p = CommentAutomapper.FromBltoUiGetAll();
            return PartialView("_list", p);
        }

        //
        // GET: /Comment/Create
        [HttpGet]
        public async Task<ActionResult> CreateComment(Guid id)
        {
            
            var newComm = new CommentViewModel();
            var alb = await AlbumAutomapper.FromBltoUiGetById(id);
           
            newComm.AlbumId = id;
            newComm.AlbumCView = alb;
            return PartialView("_CreateComment", newComm);
        }

        //
        // POST: /Comment/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateComment(CommentViewModel com)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            var identity = HttpContext.User.Identity.GetUserId();
            //var usId = CommentAutomapper.FromBltoUiGetById(com.UserId);

            //if (usId != null)
            //{
            com.Id =  Guid.NewGuid();
            com.Date = DateTime.UtcNow;
            com.UserId = new Guid(identity);
            com.AlbumId = com.AlbumId;

            await CommentAutomapper.FromBltoUiInser(com);
            return Json(new {status = 1, Message = "Added Comment Success"});
            //}

            //}
            //return Json(new { status = 1, Message = "Couldn't add comment" });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid commentID)
        {
            if (User.Identity.IsAuthenticated)
            {
                var commentToRemove = await CommentAutomapper.FromBltoUiGetById(commentID);
                if (commentToRemove != null)
                    await CommentAutomapper.FromBltoUiDeleteAsync(commentID);
                return Content("Comment was removed.");
            }


            return Content("Couldn't remove comment.");
        }
    }
}