using System;
using System.Collections.Generic;
using System.Linq;
using Datalager.Models;

namespace Datalager.Repositories
{
    public class AlbumRepository
    {
        // Spara i minnet tills vi flyttar till en databas
        public static IList<Album> Albums { get; private set; } = new List<Album>();

        public AlbumRepository()
        {
            if (!Albums.Any())
            {
                SetupTemporaryData();
            }
        }

        public void Add(Album album)
        {
            Albums.Add(album);
        }

        public void RemoveAlbum(Guid id)
        {
            var album = Albums.FirstOrDefault(x => x.AlbumId == id);
            Albums.Remove(album);
        }

        private void SetupTemporaryData()
        {
            Albums = new List<Album>
            {

             new Album {AlbumId =Guid.NewGuid(),AlbumName="Album 01",AlbumDate= Convert.ToDateTime("15/04/2017"),AlbumComment="Album 01"},
             new Album {AlbumId =Guid.NewGuid(),AlbumName="Album 02",AlbumDate= Convert.ToDateTime("16/04/2017"),AlbumComment="Album 02"}
               };

        }
    }
}
