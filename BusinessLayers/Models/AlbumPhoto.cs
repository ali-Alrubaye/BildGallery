
using System.Collections.Generic;

namespace BusinessLayers.Models
{
    public class AlbumPhoto
    {
        public IList<AlbumViewModel> Albums { get; set; }
        public IList<PhotoViewModel> Photos { get; set; }
        public IList<CommentViewModel> Comments { get; set; }
    }
}
