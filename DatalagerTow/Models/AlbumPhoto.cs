using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalagerTow.Models
{
    public class AlbumPhoto
    {
        public IList<Album> Albums { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
