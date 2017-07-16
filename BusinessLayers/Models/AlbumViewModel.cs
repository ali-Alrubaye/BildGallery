using System;
using System.Collections.Generic;

namespace BusinessLayers.Models
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            this.PhotosAView = new HashSet<PhotoViewModel>();
            CommentsAView = new HashSet<CommentViewModel>();

        }
        public Guid AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime AlbumDate { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
        public virtual UserViewModel UserAView { get; set; }

        public virtual ICollection<PhotoViewModel> PhotosAView { get; set; }
        public virtual ICollection<CommentViewModel> CommentsAView { get; set; }
    }
}
