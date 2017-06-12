using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datalager.Models;
using LabEtt.Models;

namespace LabEtt.Mapper
{
    public class PhotoMapper
    {
        internal static PhotoViewModel MapDetailsPhotoView(Photo fromRe)
        {
            var photo = new PhotoViewModel();
            photo.Id = fromRe.PhotoId;
            photo.PhotoName = fromRe.PhotoName;
            photo.PhotoDate = fromRe.PhotoDate;
            photo.Description = fromRe.Description;
            photo.PhotoPath = fromRe.PhotoPath;
            return photo;
        }
    }
}