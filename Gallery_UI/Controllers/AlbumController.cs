using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNet.Identity;

namespace Gallery_UI.Controllers
{
    public class AlbumController : Controller
    {
        public AlbumController()
        {
            AlbumAutomapper = new AlbumAutomapper();
            PhotoAutomapper = new PhotoAutomapper();
            CommentAutomapper = new CommentAutomapper();
            UserAutomapper = new UserAutomapper();
        }

        private AlbumAutomapper AlbumAutomapper { get; }
        private PhotoAutomapper PhotoAutomapper { get; }
        private UserAutomapper UserAutomapper { get; }
        private CommentAutomapper CommentAutomapper { get; }


        //
        // GET: /Album/
        public ActionResult Index()
        {
            //var g = AlbumAutomapper.FromBltoUiGetAll();
            return View();
        }


        [HttpGet]
        public ActionResult List()
        {
            var p =  AlbumAutomapper.FromBltoUiGetAll();
            return PartialView("_list", p);
        }


        // GET: /Album/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var r = await AlbumAutomapper.FromBltoUiGetById(id);
            if (r == null)
                return HttpNotFound();
            //var allpictur = await PhotoAutomapper.FromBltoUiGetAllByAlbumId(id);
            //var allcomm = await CommentAutomapper.FromBltoUiGetAll();
            //r.PhotosAView = allpictur;
            //r.CommentsAView = allcomm;
            return PartialView("_DetailsAlbum", r);
            //return View(r);
        }


        // GET: /Album/Create
        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("_CreateAlbum");
        }

        //
        // POST: /Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AlbumViewModel album)
        {
            var identity = HttpContext.User.Identity.GetUserId();


            if (string.IsNullOrWhiteSpace(album.AlbumName))
                return Json(new { status = 0, Message = "Namnet får inte vara tomt!" }, JsonRequestBehavior.AllowGet);
            if (string.IsNullOrWhiteSpace(album.Description))
                return Json(new { status = 0, Message = "Description får inte vara tomt!" },
                    JsonRequestBehavior.AllowGet);
            album.AlbumId = Guid.NewGuid();
            album.UserId = new Guid(identity);
            await AlbumAutomapper.FromBltoUiInser(album);
            return Json(new { status = 1, Message = "Added Album Success" });
        }

        //[Authorize]
        //[HttpGet]
        //public ActionResult AddCom(Guid? id)
        //{
        //    var comment = AlbumAutomapper.FromBltoUiGetById((Guid) id);
        //    return PartialView("_AddCom", comment);
        //}


        //[HttpPost]
        //public async Task<ActionResult> AddCom(AlbumViewModel album)
        //{
        //    if (ModelState.IsValid)
        //        await AlbumAutomapper.FromBltoUiEditAsync(album);
        //    return RedirectToAction("Index");
        //}


        // GET: /Album/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var editMap = await AlbumAutomapper.FromBltoUiGetById(id);
            if (editMap == null)
                return HttpNotFound();
            return PartialView("_Edit", editMap);
        }


        // POST: /Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AlbumViewModel album)
        {
            if (ModelState.IsValid)
                await AlbumAutomapper.FromBltoUiEditAsync(album);
            return RedirectToAction("Index");
        }


        // GET: /Album/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var getFromR = await AlbumAutomapper.FromBltoUiGetById(id);
            if (getFromR == null)
                return HttpNotFound();
            return PartialView("_Delete", getFromR);
        }


        // POST: /Album/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await AlbumAutomapper.FromBltoUiDeleteAsync(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> AddPhotoToAlbum(Guid id)
        {
            var model = new List<PhotoViewModel>();
            //model.Albums =  AlbumAutomapper.FromBltoUiGetAll();
            //model.Photos = await PhotoAutomapper.FromBltoUiGetAll();
            var t = await PhotoAutomapper.FromBltoUiGetAll();
            foreach (var item in t)
            {
                if (item.AlbumId == null)
                {
                    var p = new PhotoViewModel()
                    {
                        AlbumId = id,
                        PhotoId = item.PhotoId,
                        PhotoPath = item.PhotoPath,

                    };
                    model.Add(p);
                }
            }
            return PartialView("_AddPhotoToAlbum", model);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhotoToAlbum(IEnumerable<Guid> photo, Guid albumId)
        {
            if (photo == null)
                return Json(new { status = 0, Message = "Du måste välja en Photo!" }, JsonRequestBehavior.AllowGet);
            foreach (var item in photo)
            {
                var p = await PhotoAutomapper.FromBltoUiGetById(item);

                p.AlbumId = albumId;
                await PhotoAutomapper.FromBltoUiEditoUpdateAsync(p);
            }
            return Json(new { status = 1, Message = "Added Photo To Album Success" }, JsonRequestBehavior.AllowGet);
        }
    }
}