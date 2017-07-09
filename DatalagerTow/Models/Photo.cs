using System;
using System.Collections.Generic;
using System.Web;

namespace DatalagerTow.Models
{
    public class Photo
    {
        public Photo()
        {
            Comments = new HashSet<Comment>();
          
        }


        public Guid PhotoId { get; set; }
        public string PhotoName { get; set; }
        public DateTime PhotoDate { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        //public HttpPostedFileWrapper ImageFile { get; set; }
        public Guid? AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
