using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayers.Models
{
    public class AlbumPhoto
    {
        [Required]
        public IEnumerable<AlbumViewModel> Albums { get; set; }
        [Required]
        public IEnumerable<PhotoViewModel> Photos { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
