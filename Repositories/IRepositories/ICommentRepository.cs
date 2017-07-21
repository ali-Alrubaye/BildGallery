using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(Guid id);

        IQueryable<Comment> SearchFor(Expression<Func<Comment, bool>> predicate);

        Task<List<Comment>>  GetAll();

        Task EditAsync(Comment entity);

        Task InsertAsync(Comment entity);

        Task DeleteAsync(Comment entity);
    }
}
