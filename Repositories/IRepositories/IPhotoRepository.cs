using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IPhotoRepository
    {
        Task<Photo> GetByIdAsync(Guid id);

        IQueryable<Photo> SearchFor(Expression<Func<Photo, bool>> predicate);

        Task<List<Photo>> GetAll();

        Task EditoUpdateAsync(Photo entity);

        Task InsertAsync(Photo entity);

        Task DeleteAsync(Guid entity);
    }
}
