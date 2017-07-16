using System.Collections.Generic;

namespace Repositories.Models
{
    public class AlbumPhoto
    {
        public IList<Album> Albums { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
