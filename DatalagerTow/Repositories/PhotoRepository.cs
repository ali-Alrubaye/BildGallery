using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DatalagerTow.IRepositories;
using DatalagerTow.Models;

namespace DatalagerTow.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {

        // Spara i minnet tills vi flyttar till en databas
        public static IList<Photo> Photos { get; private set; } = new List<Photo>();
        public PhotoRepository()
        {
            if (!Photos.Any())
            {
                SetupTemporaryData();
            }
        }



        private void SetupTemporaryData()
        {
            AlbumRepository album = new AlbumRepository();
            var a = album.GetAll();

            Photos = new List<Photo>
            {

             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img01",PhotoDate = DateTime.UtcNow,Description="Foto 01",PhotoPath= "img01.jpg",AlbumId = a[0].AlbumId },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img02",PhotoDate = DateTime.UtcNow,Description="Foto 02",PhotoPath= "img02.jpg",AlbumId = a[1].AlbumId },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img03",PhotoDate = DateTime.UtcNow,Description="Foto 03",PhotoPath= "img03.jpg",AlbumId = a[0].AlbumId },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img04",PhotoDate = DateTime.UtcNow,Description="Foto 04",PhotoPath= "img04.jpg",AlbumId = a[1].AlbumId },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img05",PhotoDate = DateTime.UtcNow,Description="Foto 05",PhotoPath= "img05.jpg",AlbumId = a[0].AlbumId }
               };
        }


        public Photo GetByIdAsync(Guid id)
        {
            var find = Photos.FirstOrDefault(p => p.PhotoId == id);
            return find;
        }

        public List<Photo> SearchFor(Expression<Func<Photo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Photo> GetAll()
        {
            var p = Photos.ToList();
            return p;
        }

        public void EditAsync(Photo photo)
        {
            var p = photo.PhotoId;
            var ph = Photos.FirstOrDefault(x => x.PhotoId == photo.PhotoId);
            var results = (from i in Photos
                           where i.PhotoId == photo.PhotoId //here you put your predicate
                           select Photos.IndexOf(i)).FirstOrDefault();

            Photos.Remove(ph);
            Photos.Insert(results, photo);

        }

        public void InsertAsync(Photo photo)
        {
            Photos.Add(photo);
        }

        public void DeleteAsync(Guid id)
        {
            var photo = Photos.FirstOrDefault(x => x.PhotoId == id);
            Photos.Remove(photo);
        }

        #region Hejlp Method

        public List<Photo> GetPhotoByAlbumId(Guid id)
        {
            var find = Photos.Where(p => p.AlbumId == id).ToList();
            return find;
        }
      
        #endregion
    }
}
