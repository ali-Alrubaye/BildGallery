using System.Collections.Generic;

namespace Datalager.Models
{
    public class AlbumPhoto
    {
        public IList<Album> Albums { get; set; }
        public IList<Photo> Photos { get; set; }
    }
}