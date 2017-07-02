using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DatalagerTow.IRepositories;
using DatalagerTow.Models;

namespace DatalagerTow.Repositories
{
    public class AlbumRepository: IAlbumRepository
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

        private void SetupTemporaryData()
        {
            UserRepositories user = new UserRepositories();
            var u = user.GetAll();

            Albums = new List<Album>
            {

             new Album {AlbumId =Guid.NewGuid(),AlbumName="Album 01",AlbumDate= DateTime.UtcNow,Description= "Album 01",UserId = u[0].Id},
             new Album {AlbumId =Guid.NewGuid(),AlbumName="Album 02",AlbumDate= DateTime.UtcNow,Description= "Album 02",UserId = u[1].Id}
               };

        }

        public Album GetByIdAsync(Guid id)
        {
            var result = Albums.FirstOrDefault(a => a.AlbumId == id);
            return result;
        }

        public List<Album> SearchFor(Expression<Func<Album, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Album> GetAll()
        {
            return Albums.ToList();
        }

        public void EditAsync(Album album)
        {
            throw new NotImplementedException();
        }

        public void InsertAsync(Album album)
        {
            Albums.Add(album);
        }

        public void DeleteAsync(Guid id)
        {
            var album = Albums.FirstOrDefault(x => x.AlbumId == id);
            Albums.Remove(album);
        }
    }
}
