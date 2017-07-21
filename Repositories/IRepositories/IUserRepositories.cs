using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);

        IQueryable<User> SearchFor(Expression<Func<User, bool>> predicate);

        Task<List<User>> GetAll();

        Task EditAsync(User entity);

        Task InsertAsync(User entity);

        Task DeleteAsync(User entity);
        Task<User> CheckUserOpwd(User entity);
    }
}