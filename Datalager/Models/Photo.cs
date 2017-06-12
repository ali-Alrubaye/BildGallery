using System;

namespace Datalager.Models
{
    public class Photo
    {
        public Photo()
        {
            PhotoId = Guid.NewGuid();
        }


        public Guid PhotoId { get; set; }
        public string PhotoName { get; set; }

        public DateTime PhotoDate { get; set; }
        public string PhotoComment { get; set; }
        public string PhotoPath { get; set; }
        public Guid AlbumId { get; set; }
        public virtual Album Album { get; set; }

    }
}
