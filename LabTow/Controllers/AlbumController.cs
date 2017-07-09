using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLayer.MapperClass;
using BusinessLayer.Models;

namespace LabTow.Controllers
{
    public class AlbumController : Controller
    {

        private AlbumAutomapper AlbumAutomapper { get; set; }
        private PhotoAutomapper PhotoAutomapper { get; set; }
        private CommentAutomapper CommentAutomapper { get; set; }

        public AlbumController()
        {
            AlbumAutomapper = new AlbumAutomapper();
            PhotoAutomapper = new PhotoAutomapper();
            CommentAutomapper = new CommentAutomapper();
        }
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
            var p = AlbumAutomapper.FromBltoUiGetAll().OrderBy(x => x.AlbumDate);
            return PartialView("_list", p);
        }
        //
        // GET: /Album/Details/5
        public ActionResult Details(Guid id)
        {
            var r =  AlbumAutomapper.FromBltoUiGetById(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            var allpictur = PhotoAutomapper.FromBltoUiGetAllByAlbumId(id);
            r.PhotosAView = allpictur;
            //return PartialView("_DetailsAlbum",r);
            return View(r);
        }

        //
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
            {
                return Json(new { status = 0, Message = "Namnet får inte vara tomt!" }, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrWhiteSpace(album.Description))
            {
                return Json(new { status = 0, Message = "Description får inte vara tomt!" }, JsonRequestBehavior.AllowGet);
            }
            album.AlbumId = Guid.NewGuid();
             AlbumAutomapper.FromBltoUiInser(album);
            return Json(new { status = 1, Message = "Added Photo Success" });
        }
        [HttpGet]
        public ActionResult AddCom(Guid? id)
        {
            var comment =  AlbumAutomapper.FromBltoUiGetById((Guid)id);
            return PartialView("_AddCom", comment);
        }
        [HttpPost]
        public ActionResult AddCom(AlbumViewModel album)
        {
            if (ModelState.IsValid)
            {
                 AlbumAutomapper.FromBltoUiEditAsync(album);
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        //
        // GET: /Album/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var editMap =  AlbumAutomapper.FromBltoUiGetById(id);
            if (editMap == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", editMap);
        }

        //
        // POST: /Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumViewModel album)
        {
            if (ModelState.IsValid)
            {
                 AlbumAutomapper.FromBltoUiEditAsync(album);
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Album/Delete/5
        public ActionResult Delete(Guid id)
        {
            var getFromR =  AlbumAutomapper.FromBltoUiGetById(id);
            if (getFromR == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", getFromR);
        }

        //
        // POST: /Album/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
             AlbumAutomapper.FromBltoUiDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}