
using System.Collections.Generic;

namespace ViewModels.Models
{
    public class AlbumPhoto
    {
        public IList<AlbumViewModel> Albums { get; set; }
        public IList<PhotoViewModel> Photos { get; set; }
        public IList<CommentViewModel> Comments { get; set; }
    }
}
