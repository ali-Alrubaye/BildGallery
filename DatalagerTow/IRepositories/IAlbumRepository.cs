using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DatalagerTow.Models;

namespace DatalagerTow.IRepositories
{
    public interface IAlbumRepository
    {

        Album GetByIdAsync(Guid id);

        List<Album> SearchFor(Expression<Func<Album, bool>> predicate);

        List<Album> GetAll();

        void EditAsync(Album album);

        void InsertAsync(Album album);

        void DeleteAsync(Guid id);
    }
}
