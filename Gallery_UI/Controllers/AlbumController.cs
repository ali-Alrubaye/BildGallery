using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;

namespace Gallery_UI.Controllers
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


        // GET: /Album/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var r = AlbumAutomapper.FromBltoUiGetById(id);
            if (r == null)
                return HttpNotFound();
            //var allpictur = await PhotoAutomapper.FromBltoUiGetAllByAlbumId(id);
            //var allcomm = await CommentAutomapper.FromBltoUiGetCommentByAlbumId(id);
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
            if (string.IsNullOrWhiteSpace(album.AlbumName))
                return Json(new {status = 0, Message = "Namnet får inte vara tomt!"}, JsonRequestBehavior.AllowGet);
            if (string.IsNullOrWhiteSpace(album.Description))
                return Json(new {status = 0, Message = "Description får inte vara tomt!"},
                    JsonRequestBehavior.AllowGet);
            album.AlbumId = Guid.NewGuid();
            await AlbumAutomapper.FromBltoUiInser(album);
            return Json(new {status = 1, Message = "Added Photo Success"});
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddCom(Guid? id)
        {
            var comment = AlbumAutomapper.FromBltoUiGetById((Guid) id);
            return PartialView("_AddCom", comment);
        }


        [HttpPost]
        public async Task<ActionResult> AddCom(AlbumViewModel album)
        {
            if (ModelState.IsValid)
                await AlbumAutomapper.FromBltoUiEditAsync(album);
            return RedirectToAction("Index");
        }


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
        public ActionResult AddPhotoToAlbum()
        {
            var model = new AlbumPhoto();
            //model.Albums = AlbumAutomapper.FromBltoUiGetAll();
            model.Photos = PhotoAutomapper.FromBltoUiGetAll();
            return PartialView("_AddPhotoToAlbum", model);
        }


        [HttpPost]
        public async Task<ActionResult> AddPhotoToAlbum(IEnumerable<Guid> photo, Guid albumId)
        {
            var album = await AlbumAutomapper.FromBltoUiGetById(albumId);
            foreach (var item in photo)
            {
                var p = await PhotoAutomapper.FromBltoUiGetById(item);
                //album.PhotosAView.Add(p);
                p.AlbumId = albumId;
                await PhotoAutomapper.FromBltoUiInser(p);
            }
            return Content("OK!");
        }
    }
}