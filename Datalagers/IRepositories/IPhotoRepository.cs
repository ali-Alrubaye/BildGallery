using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Datalagers.Models;

namespace Datalagers.IRepositories
{
    public interface IPhotoRepository
    {
        Photo GetByIdAsync(Guid id);

        List<Photo> SearchFor(Expression<Func<Photo, bool>> predicate);

        List<Photo> GetAll();

        void EditAsync(Photo photo);

        void InsertAsync(Photo photo);

        void DeleteAsync(Guid id);
    }
}
