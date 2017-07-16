using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLayer.MapperClass;
using BusinessLayer.Models;

namespace LabTow.Controllers
{
  
    public class AlbumController : Controller
    {
        public AlbumController()
        {
            AlbumAutomapper = new AlbumAutomapper();
            PhotoAutomapper = new PhotoAutomapper();
            CommentAutomapper = new CommentAutomapper();
        }

        private AlbumAutomapper AlbumAutomapper { get; }
        private PhotoAutomapper PhotoAutomapper { get; }

        private CommentAutomapper CommentAutomapper { get; }

        [AllowAnonymous]
        //
        // GET: /Album/
        public ActionResult Index()
        {
            //var g = AlbumAutomapper.FromBltoUiGetAll();
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult List()
        {
            var p = AlbumAutomapper.FromBltoUiGetAll().OrderBy(x => x.AlbumDate);
            return PartialView("_list", p);
        }

        [Authorize]
        // GET: /Album/Details/5
        public ActionResult Details(Guid id)
        {
            var r = AlbumAutomapper.FromBltoUiGetById(id);
            if (r == null)
                return HttpNotFound();
            var allpictur = PhotoAutomapper.FromBltoUiGetAllByAlbumId(id);
            var allcomm = CommentAutomapper.FromBltoUiGetCommentByAlbumId(id);
            r.PhotosAView = allpictur;
            r.CommentsAView = allcomm;
            return PartialView("_DetailsAlbum", r);
            //return View(r);
        }

        [Authorize]
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
        public ActionResult Create(AlbumViewModel album)
        {
            if (string.IsNullOrWhiteSpace(album.AlbumName))
                return Json(new { status = 0, Message = "Namnet får inte vara tomt!" }, JsonRequestBehavior.AllowGet);
            if (string.IsNullOrWhiteSpace(album.Description))
                return Json(new { status = 0, Message = "Description får inte vara tomt!" },
                    JsonRequestBehavior.AllowGet);
            album.AlbumId = Guid.NewGuid();
            AlbumAutomapper.FromBltoUiInser(album);
            return Json(new { status = 1, Message = "Added Photo Success" });
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddCom(Guid? id)
        {
            var comment = AlbumAutomapper.FromBltoUiGetById((Guid)id);
            return PartialView("_AddCom", comment);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddCom(AlbumViewModel album)
        {
            if (ModelState.IsValid)
                AlbumAutomapper.FromBltoUiEditAsync(album);
            return RedirectToAction("Index");
        }

        [Authorize]
        // GET: /Album/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var editMap = AlbumAutomapper.FromBltoUiGetById(id);
            if (editMap == null)
                return HttpNotFound();
            return PartialView("_Edit", editMap);
        }

        [Authorize]
        // POST: /Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumViewModel album)
        {
            if (ModelState.IsValid)
                AlbumAutomapper.FromBltoUiEditAsync(album);
            return RedirectToAction("Index");
        }

        [Authorize]
        // GET: /Album/Delete/5
        public ActionResult Delete(Guid id)
        {
            var getFromR = AlbumAutomapper.FromBltoUiGetById(id);
            if (getFromR == null)
                return HttpNotFound();
            return PartialView("_Delete", getFromR);
        }

        [Authorize]
        // POST: /Album/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AlbumAutomapper.FromBltoUiDeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddPhotoToAlbum()
        {
            var model = new AlbumPhoto();
            model.Albums = AlbumAutomapper.FromBltoUiGetAll();
            model.Photos = PhotoAutomapper.FromBltoUiGetAll();
            return PartialView("_AddPhotoToAlbum", model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddPhotoToAlbum(IEnumerable<Guid> photo, Guid albumId)
        {
            var album = AlbumAutomapper.FromBltoUiGetById(albumId);
            foreach (var item in photo)
            {
                var p = PhotoAutomapper.FromBltoUiGetById(item);
                //album.PhotosAView.Add(p);
                p.AlbumId = albumId;
                PhotoAutomapper.FromBltoUiInser(p);
            }
            return Content("OK!");
        }
    }
}