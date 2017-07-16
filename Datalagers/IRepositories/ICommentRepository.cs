using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Datalagers.Models;

namespace Datalagers.IRepositories
{
    public interface ICommentRepository
    {
        Comment GetByIdAsync(Guid id);

        List<Comment> SearchFor(Expression<Func<Comment, bool>> predicate);

        List<Comment> GetAll();

        void EditAsync(Comment comment);

        void InsertAsync(Comment comment);

        void DeleteAsync(Guid id);
    }
}
