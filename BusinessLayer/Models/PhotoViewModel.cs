using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
    public class PhotoViewModel
    {
        public PhotoViewModel()
        {
            CommentsPView = new HashSet<CommentViewModel>();
            //PhotoId = Guid.NewGuid();
            //PhotoDate = DateTime.UtcNow;
        }

        [Required]
        public Guid PhotoId { get; set; }
        [Required(ErrorMessage = "Namnet får inte vara tomt!")]
        [Display(Name = "Photo Name")]
        [MaxLength(100)]
        public string PhotoName { get; set; }
        [Required]
        public DateTime PhotoDate { get; set; }

        [Required(ErrorMessage = "Description får inte vara tomt!")]
        [Display(Name = "Descriptions")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "En fil vill jag gärna att du laddar upp!")]
        public string PhotoPath { get; set; }
        //[Required(ErrorMessage = "En fil vill jag gärna att du laddar upp!")]
        //public HttpPostedFileWrapper ImageFile { get; set; }
        [Display(Name = "Album")]
        public Guid? AlbumId { get; set; }
        public virtual AlbumViewModel AlbumPView { get; set; }
        public virtual ICollection<CommentViewModel> CommentsPView { get; set; }
    }
}
