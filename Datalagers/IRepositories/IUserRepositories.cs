using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Datalagers.Models;

namespace Datalagers.IRepositories
{
    interface IUserRepositories
    {
        User GetByIdAsync(Guid id);

        List<User> SearchFor(Expression<Func<User, bool>> predicate);

        List<User> GetAll();

        void EditAsync(User entity);

        void InsertAsync(User entity);

        void DeleteAsync(Guid Id);
    }
}
