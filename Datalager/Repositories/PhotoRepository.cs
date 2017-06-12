using System;
using System.Collections.Generic;
using System.Linq;
using Datalager.Models;

namespace Datalager.Repositories
{
   public class PhotoRepository
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

        public void Add(Photo photo)
        {
            Photos.Add(photo);
        }

        public void Remove(Guid id)
        {
            var photo = Photos.Where(x => x.PhotoId == id).FirstOrDefault();
            Photos.Remove(photo);
        }

        private void SetupTemporaryData()
        {
            Photos = new List<Photo>
            {

             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img01",PhotoComment="Foto 01",PhotoPath="img01.jpg" },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img02",PhotoComment="Foto 02",PhotoPath="img02.jpg" },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img03",PhotoComment="Foto 03",PhotoPath="img03.jpg" },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img04",PhotoComment="Foto 04",PhotoPath="img04.jpg" },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img05",PhotoComment="Foto 05",PhotoPath="img05.jpg" }
               };

        }
    }
}
