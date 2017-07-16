using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BusinessLayers.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Id = Guid.NewGuid();
            PhotosUView = new HashSet<PhotoViewModel>();
            CommentsUView = new HashSet<CommentViewModel>();
            AlbumsUView = new HashSet<AlbumViewModel>();
        }
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserN { get; set; }
        public bool IsAdministrator { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }

        public virtual ICollection<PhotoViewModel> PhotosUView { get; set; }
        public virtual ICollection<CommentViewModel> CommentsUView { get; set; }
        public virtual ICollection<AlbumViewModel> AlbumsUView { get; set; }
    }
}