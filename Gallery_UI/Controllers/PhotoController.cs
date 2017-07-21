using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;

namespace Gallery_UI.Controllers
{
    public class PhotoController : Controller
    {
        public PhotoController()
        {
            _albumAutomapper = new AlbumAutomapper();
            _photoAutomapper = new PhotoAutomapper();
            _commentAutomapper = new CommentAutomapper();
            _userAutomapper = new UserAutomapper();
        }

        private AlbumAutomapper _albumAutomapper { get; }
        private PhotoAutomapper _photoAutomapper { get; }
        private CommentAutomapper _commentAutomapper { get; }

        private UserAutomapper _userAutomapper { get; }

        // GET: /photo/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var p =await _photoAutomapper.FromBltoUiGetAll();

            return PartialView("_list", p);
        }

        //
        // GET: /photo/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var r = await _photoAutomapper.FromBltoUiGetById(id);
            if (r == null)
                return HttpNotFound();
            return PartialView("_Details", r);
        }

        //
        // GET: /photo/Create
        [HttpGet]
        public PartialViewResult Create()
        {
            //var alb =  _albumAutomapper.FromBltoUiGetAll();
            //ViewBag.AlbumId = new SelectList(alb.OrderByDescending(x => x.AlbumId), "AlbumId", "AlbumName");

            return PartialView("_CreatePhotos");
        }

        //
        // POST: /photo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PhotoViewModel photo, HttpPostedFileBase photoPath)
        {
            //Thread.Sleep(5000);
            if (string.IsNullOrWhiteSpace(photo.PhotoName))
                return Json(new {status = 0, Message = "Namnet får inte vara tomt!"}, JsonRequestBehavior.AllowGet);
            if (string.IsNullOrWhiteSpace(photo.Description))
                return Json(new {status = 0, Message = "Description får inte vara tomt!"},
                    JsonRequestBehavior.AllowGet);
            var destination = Server.MapPath("~/GalleryImages/");
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);
            if (photoPath == null || photoPath.ContentLength == 0)
                return Json(new {Status = 0, Message = "En fil vill jag gärna att du laddar upp!"},
                    JsonRequestBehavior.AllowGet);
            var fileName = Path.GetFileName(photoPath.FileName);
            if (fileName != null)
            {
                var path = Path.Combine(destination, fileName);
                photoPath.SaveAs(path);
            }


            photo.PhotoPath = photoPath.FileName;
            photo.PhotoId = Guid.NewGuid();
            photo.PhotoDate = DateTime.UtcNow;
            await _photoAutomapper.FromBltoUiInser(photo);

            //ViewBag.AlbumId =
            //    new SelectList(_albumAutomapper.FromBltoUiGetAll().OrderBy(x => x.AlbumId == photo.PhotoId), "AlbumId",
            //        "AlbumName");

            return Json(new {status = 1, Message = "Added Photo Success"});
        }

        //
        // GET: /photo/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var editMap = await _photoAutomapper.FromBltoUiGetById(id);
            ViewBag.AlbumId =
                new SelectList(_albumAutomapper.FromBltoUiGetAll().OrderBy(x => x.AlbumId == editMap.AlbumId),
                    "AlbumId", "AlbumName");
            if (editMap == null)
                return HttpNotFound();
            return PartialView("_Edit", editMap);
        }


        //
        // POST: /photo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PhotoViewModel photo, HttpPostedFileBase photoPath)
        {
            var destination = Server.MapPath("~/GalleryImages/");
            if (photoPath != null && photoPath.ContentLength > 0)
            {
                var path = Path.Combine(destination, photoPath.FileName);
                photoPath.SaveAs(path);
                photo.PhotoPath = photoPath.FileName;

                photo.PhotoDate = DateTime.UtcNow;
                await RemoveOldFileIfExists(photo);
            }
            if (ModelState.IsValid)
            {
                await _photoAutomapper.FromBltoUiEditoUpdateAsync(photo);
                //ViewBag.AlbumId =
                //    new SelectList(_albumAutomapper.FromBltoUiGetAll().OrderBy(x => x.AlbumId == photo.PhotoId),
                //        "AlbumId", "AlbumName");
                return Json(new {status = 1, Message = "Edit Photo Success"});
            }

            return Json(new {status = 1, Message = "Cannot Edit Photo"});
        }

        //
        // GET: /photo/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var getFromR = await _photoAutomapper.FromBltoUiGetById(id);
            if (getFromR == null)
                return HttpNotFound();
            return PartialView("_Delete", getFromR);
        }

        //
        // POST: /photo/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var deletpicture = await _photoAutomapper.FromBltoUiGetById(id);
            var destination = Server.MapPath("~/GalleryImages/" + deletpicture.PhotoPath);
            if (deletpicture.PhotoPath != null)
            {
                var file = new FileInfo(destination);
                if (file.Exists)
                    file.Delete();
            }
            await _photoAutomapper.FromBltoUiDeleteAsync(id);
            return Json(new {Message = "Delete Photo Success"}, JsonRequestBehavior.AllowGet);
        }

        private async Task RemoveOldFileIfExists(PhotoViewModel picture)
        {
            var oldpicture = await _photoAutomapper.FromBltoUiGetById(picture.PhotoId);
            if (oldpicture.PhotoPath != picture.PhotoPath)
            {
                var oldPhysicalPath = Request.MapPath(oldpicture.PhotoPath);
                var oldfile = new FileInfo(oldPhysicalPath);
                if (oldfile.Exists)
                    oldfile.Delete();
            }
        }
    }
}