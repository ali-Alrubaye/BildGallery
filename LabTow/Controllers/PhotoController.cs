using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MapperClass;
using BusinessLayer.Models;

namespace LabTow.Controllers
{
    public class PhotoController : Controller
    {
        private AlbumAutomapper _albumAutomapper { get; set; }
        private PhotoAutomapper _photoAutomapper { get; set; }
        private CommentAutomapper _commentAutomapper { get; set; }
        private UserAutomapper _userAutomapper { get; set; }

        public PhotoController()
        {
            _albumAutomapper = new AlbumAutomapper();
            _photoAutomapper = new PhotoAutomapper();
            _commentAutomapper = new CommentAutomapper();
            _userAutomapper = new UserAutomapper();
        }
        // GET: /photo/
        public ActionResult Index()
        {
            var p = _photoAutomapper.FromBltoUiGetAll().OrderBy(x => x.PhotoDate);
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var p = _photoAutomapper.FromBltoUiGetAll().OrderBy(x => x.PhotoDate);
            
            return PartialView("_list", p);
        }

        //
        // GET: /photo/Details/5
        public ActionResult Details(Guid id)
        {
            var r =  _photoAutomapper.FromBltoUiGetById(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        //
        // GET: /photo/Create
        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.AlbumId = new SelectList(_albumAutomapper.FromBltoUiGetAll().OrderByDescending(x => x.AlbumId), "AlbumId", "AlbumName");
            return PartialView("_CreatePhotos");
        }

        //
        // POST: /photo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhotoID,PhotoName,PhotoDate,Description,PhotoPath,AlbumId")] PhotoViewModel photo, HttpPostedFileBase photoPath)
        {
            if (string.IsNullOrWhiteSpace(photo.PhotoName))
            {
                return Json(new { status = 0, Message = "Namnet får inte vara tomt!" }, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrWhiteSpace(photo.Description))
            {
                return Json(new { status = 0, Message = "Description får inte vara tomt!" }, JsonRequestBehavior.AllowGet);
            }
            if (photoPath == null || photoPath.ContentLength == 0)
            {
                return Json(new { status = 0, Message = "En fil vill jag gärna att du laddar upp!" }, JsonRequestBehavior.AllowGet);
            }
            var destination = Server.MapPath("~/GalleryImages/");
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            photo.PhotoPath = photoPath.FileName;
            photo.PhotoId = Guid.NewGuid();
            photo.PhotoDate = DateTime.UtcNow;
            _photoAutomapper.FromBltoUiInser(photo);
            ViewBag.AlbumId = new SelectList(_albumAutomapper.FromBltoUiGetAll().OrderBy(x => x.AlbumId), "AlbumId", "AlbumName");
            return Json(new { status = 1, Message = "Added Photo Success" });
        }

        //
        // GET: /photo/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ViewBag.AlbumId = new SelectList(_albumAutomapper.FromBltoUiGetAll().OrderBy(x => x.AlbumId == id), "AlbumId", "AlbumName");
            var editMap =  _photoAutomapper.FromBltoUiGetById(id);

            if (editMap == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", editMap);
        }

        //
        // POST: /photo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhotoViewModel photo)
        {
            if (ModelState.IsValid)
            {
                 _photoAutomapper.FromBltoUiEditAsync(photo);
                ViewBag.AlbumId = new SelectList(_albumAutomapper.FromBltoUiGetAll().OrderBy(x => x.AlbumId == photo.PhotoId), "AlbumId", "AlbumName");
                return RedirectToAction("Index");
            }

            return RedirectToAction("List");
        }

        //
        // GET: /photo/Delete/5
        public ActionResult Delete(Guid id)
        {
            var getFromR =  _photoAutomapper.FromBltoUiGetById(id);
            if (getFromR == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", getFromR);
        }

        //
        // POST: /photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
             _photoAutomapper.FromBltoUiDeleteAsync(id);
            return Json(new { Message = "Delete Photo Success" }, JsonRequestBehavior.AllowGet);
        }
    }
}