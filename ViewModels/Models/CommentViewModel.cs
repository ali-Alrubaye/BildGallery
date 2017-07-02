using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
   public class CommentViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Content får inte vara tomt!")]
        [Display(Name = "Comment")]
        [MaxLength(100)]
        public string Content { get; set; }
        [Display(Name = "Date Posted")]
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public virtual UserViewModel UserCView { get; set; }

        public Guid? PhotoId { get; set; }
        public virtual PhotoViewModel PhotoCView { get; set; }

        public Guid? AlbumId { get; set; }
        public virtual AlbumViewModel AlbumCView { get; set; }
    }
}
