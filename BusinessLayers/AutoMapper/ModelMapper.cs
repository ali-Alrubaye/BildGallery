using BusinessLayers.Models;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayers.AutoMapper
{
   public static class ModelMapper
    {
        #region Users
        public static User ModelToDbUser(UserViewModel model)
        {
            var user = new User();
            user.Id = model.Id;
            user.UserN = model.UserN;
            user.Email = model.Email;
            user.IsAdministrator = model.IsAdministrator;
            user.Pwd = model.Pwd;

            return user;

        }

        public static UserViewModel DbToModelUser(User db)
        {
            var model = new UserViewModel();
            model.Id = db.Id;
            model.UserN = db.UserN;
            model.Email = db.Email;
            model.IsAdministrator = db.IsAdministrator;
            model.Pwd = db.Pwd;

            return model;


        }
        #endregion

        #region Album
        public static Album ModelToDbAlp(AlbumViewModel model)
        {
            var albDb = new Album();
            albDb.AlbumId = model.AlbumId;
            albDb.AlbumName = model.AlbumName;
            albDb.AlbumDate = model.AlbumDate;
            albDb.Description = model.Description;
            albDb.UserId = model.UserId;
            

            return albDb;

        }

        public static AlbumViewModel DbToModelAlb(Album db)
        {
            var AlbMod = new AlbumViewModel();
            AlbMod.AlbumId = db.AlbumId;
            AlbMod.AlbumName = db.AlbumName;
            AlbMod.AlbumDate = db.AlbumDate;
            AlbMod.Description = db.Description;
            AlbMod.UserId = db.UserId;
            AlbMod.UserAView = DbToModelUser(db.User);
            return AlbMod;


        }

        //private static ICollection<PhotoViewModel> testPhoto(ICollection<Photo> photos)
        //{
        //    var ph = new PhotoViewModel();
        //    //ph.Select(x => new Photo()
        //    //{
        //    //    PhotoId = x.PhotoId,
        //    //    PhotoDate = x.PhotoDate,
        //    //    PhotoName = x.PhotoName,
        //    //    PhotoPath = x.PhotoPath,

        //    //});
        //    foreach (var item in photos)
        //    {
        //        ph.PhotoId = item.PhotoId;
        //        ph.PhotoName = item.PhotoName;
        //        ph.PhotoDate = item.PhotoDate;
        //        ph.Description = item.Description;
        //        ph.PhotoPath = item.PhotoPath;

        //    }
        //    return ph;
        //}

        
        #endregion
        #region Comment
        public static Comment ModelToDb(CommentViewModel model)
        {
            var comDb = new Comment();
            comDb.Id = model.Id;
            comDb.Content = model.Content;
            comDb.Date = model.Date;
            comDb.UserId = model.UserId;
            comDb.PhotoId = model.PhotoId;

            return comDb;

        }

        public static CommentViewModel DbToModel(Comment db)
        {
            var comMod = new CommentViewModel();
            comMod.Id = db.Id;
            comMod.Content = db.Content;
            comMod.Date = db.Date;
            comMod.UserId = db.UserId;
            comMod.UserCView = DbToModelUser(db.User);
            comMod.AlbumId = db.AlbumId;
            comMod.AlbumCView = DbToModelAlb(db.Album);

            return comMod;


        }
        #endregion

        #region Photo
        public static Photo ModelToDbPhoto(PhotoViewModel model)
        {
            var photDb = new Photo();
            photDb.PhotoId = model.PhotoId;
            photDb.PhotoName = model.PhotoName;
            photDb.PhotoDate = model.PhotoDate;
            photDb.PhotoPath = model.PhotoPath;
            photDb.Description = model.Description;
            photDb.AlbumId = model.AlbumId;


            return photDb;

        }

        public static PhotoViewModel DbToModelPhoto(Photo db)
        {
            var photMod = new PhotoViewModel();
            photMod.PhotoId = db.PhotoId;
            photMod.PhotoName = db.PhotoName;
            photMod.PhotoDate = db.PhotoDate;
            photMod.Description = db.Description;
            photMod.AlbumId = db.AlbumId;
            photMod.AlbumPView = DbToModelAlb(db.Album);

            return photMod;


        }
        #endregion
    }
}
