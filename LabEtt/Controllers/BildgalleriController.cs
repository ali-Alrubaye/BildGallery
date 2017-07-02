using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datalager.Models;
using Datalager.Repositories;
using LabEtt.Mapper;
using LabEtt.Models;

namespace LabEtt.Controllers
{
   
    public class BildgalleriController : Controller
    {
        public PhotoRepository PhotoRepository { get; set; }
        public BildgalleriController()
        {
            PhotoRepository = new PhotoRepository();
        }
        [AllowAnonymous]
        // GET: Gallery
        public ActionResult Index()
        {

            return View();
        }
        [Authorize]
        // GET: Gallery/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Detail = PhotoRepository.Photos.Where(g => g.PhotoId == id).FirstOrDefault();
            if (Detail == null)
            {
                return HttpNotFound();
            }
            return View(Detail);
        }

        //GET 
        [Authorize]
        [HttpGet]
        public ActionResult Upload()
        {
            return View("Index");
        }
        // POST: Gallery/Create
        [Authorize]
        [HttpPost]
        public ActionResult Upload(PhotoViewModel addGallery, HttpPostedFileBase file)
        {
            if (string.IsNullOrWhiteSpace(addGallery.PhotoName))
            {
                ModelState.AddModelError("error", "Namnet får inte vara tomt!");
                return View(addGallery);
            }
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("error", "En fil vill jag gärna att du laddar upp!");

                // Vi skickar med model tillbaka så att vi kan få Name förifyllt!
                return PartialView(addGallery);
            }
            var destination = Server.MapPath("~/GalleryFolder/");
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            file.SaveAs(Path.Combine(destination, file.FileName));
            var photo = new Photo
            {
                PhotoId = Guid.NewGuid(),
                PhotoPath = file.FileName,
                PhotoName = addGallery.PhotoName,
                Description= addGallery.Description
            };
            PhotoRepository.Add(photo);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {

            return View(PhotoRepository.Photos);
        }
        // GET: Gallery/Edit/5
        [Authorize]
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var E = PhotoRepository.Photos.FirstOrDefault(c=> c.PhotoId == id);
           
            var rr= PhotoMapper.MapDetailsPhotoView(E);
            return View(rr);
        }

        // POST: Gallery/Edit/5
        [Authorize]
        [HttpPost]        
        public ActionResult Edit(Guid id, PhotoViewModel EG)
        {
            try
            {
                var E = PhotoRepository.Photos.FirstOrDefault(p => p.PhotoId == id);
                E.PhotoId = EG.Id;
                E.PhotoName = EG.PhotoName;
                E.PhotoDate = EG.PhotoDate;
                E.PhotoPath = EG.PhotoPath;
                

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gallery/Delete/5
        [Authorize]
        public ActionResult Delete(Guid id)
        {
            //var D =  PhotoRepository.Photos.Where(d => d.ID == id).FirstOrDefault();
            PhotoRepository.Remove(id);

            return RedirectToAction("List");
        }

        // POST: Gallery/Delete/5
        //[HttpPost]
        //public ActionResult Delete(Guid id, Gallery DG)
        //{
        //    try
        //    {
        //        var D = gallerys.Where(d => d.GalleryID == id).FirstOrDefault();
        //        gallerys.Remove(D);

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public List<Photo> GalleryList()
        {
            var gallerisModels = new List<Photo>();
            #region
            //var Gga = new List<Gallery>();
            //var path = Directory.GetDirectories(Server.MapPath("~/GalleryFolder"));

            //foreach (var G in path)
            //{
            //    var info = new FileInfo(G);
            //    GallerisModels.Add(new Gallery
            //    {
            //        GalleryID = info.Name,
            //        Path = $"/GalleryFolder/{info.Name}",
            //        PhotoN = info.Name

            //    });
            //}

            //var Gall = (from ga in GallerisModels
            //         select ga.GalleryID).LastOrDefault();
            #endregion
            var path2 = Directory.GetFiles(Server.MapPath("~/GalleryFolder/"));
            foreach (var item in path2)
            {
                var infoa = new FileInfo(item);
                gallerisModels.Add(new Photo
                {
                    PhotoId = new Guid(),
                    PhotoName = infoa.Name,
                    PhotoPath = $"/GalleryFolder/{infoa.Name}",
                    Description = "New Photo"

                });

            }
            #region
            //var p = (from ga in GallerisModels
            //         select ga.AlbumID).Last();

            //var path3 = Directory.GetFiles(Server.MapPath("~/GalleryFolder/" + a+"/"+p));
            //foreach (var aa in path2)
            //{
            //    var infoa = new FileInfo(aa);
            //    GallerisModels.Add(new Gallery
            //    {
            //        AlbumID = infoa.Name,
            //        Path = infoa.DirectoryName

            //    });
            //}
            #endregion

            return gallerisModels;
        }
    }
}