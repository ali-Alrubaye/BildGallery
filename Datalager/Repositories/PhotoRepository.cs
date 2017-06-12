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
        public static IList<AppUser> Users { get; private set; } = new List<AppUser>();
        public PhotoRepository()
        {
            if (!Photos.Any()|| !Users.Any() )
            {
                SetupTemporaryData();
                SetUserDataLogin();
            }
        }

        public void Add(Photo photo)
        {
            Photos.Add(photo);
        }

        public void Remove(Guid id)
        {
            var photo = Photos.FirstOrDefault(x => x.PhotoId == id);
            Photos.Remove(photo);
        }

        private void SetupTemporaryData()
        {
            Photos = new List<Photo>
            {

             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img01",PhotoDate = DateTime.UtcNow,Description="Foto 01",PhotoPath="img01.jpg" },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img02",PhotoDate = DateTime.UtcNow,Description="Foto 02",PhotoPath="img02.jpg" },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img03",PhotoDate = DateTime.UtcNow,Description="Foto 03",PhotoPath="img03.jpg" },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img04",PhotoDate = DateTime.UtcNow,Description="Foto 04",PhotoPath="img04.jpg" },
             new Photo {PhotoId=Guid.NewGuid(),PhotoName="img05",PhotoDate = DateTime.UtcNow,Description="Foto 05",PhotoPath="img05.jpg" }
               };
        }

       private void SetUserDataLogin()
       {
            Users = new List<AppUser>
        {
            new AppUser { IsAdministrator = true,Id = new Guid(), Email = "Admin@admin.com", UserN = "Admin", Pwd = "Admin@123"},
            new AppUser { IsAdministrator = false,Id = new Guid(), Email = "User1@user.com", UserN = "User1", Pwd = "Admin@123"}
        };
        }
    }
}
