using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Namnet får inte vara tomt!")]
        [Display(Name = "Album Name")]
        [MaxLength(100)]
        public string AlbumName { get; set; }
        [Required]
        public DateTime AlbumDate { get; set; }
        [Required(ErrorMessage = "Description får inte vara tomt!")]
        [Display(Name = "Descriptions")]
        [MaxLength(500)]
        public string Description { get; set; }

        public Guid UserId { get; set; }
        public virtual UserViewModel UserAView { get; set; }

        public virtual ICollection<PhotoViewModel> PhotosAView { get; set; }
        public virtual ICollection<CommentViewModel> CommentsAView { get; set; }
    }
}
