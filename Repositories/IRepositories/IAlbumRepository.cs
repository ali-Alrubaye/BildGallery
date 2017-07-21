using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repositories.Models;

namespace Repositories.IRepositories
{
    public interface IAlbumRepository
    {
        Task<Album> GetByIdAsync(Guid id);

        IQueryable<Album> SearchFor(Expression<Func<Album, bool>> predicate);

        IEnumerable<Album> GetAll();

        Task EditAsync(Album entity);

        Task InsertAsync(Album entity);

        Task DeleteAsync(Guid entity);
       
    }
}