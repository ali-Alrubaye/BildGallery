using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Datalagers.IRepositories;
using Datalagers.Models;

namespace Datalagers.Repositories
{
    public class UserRepositories: IUserRepositories 
    {
        // Spara i minnet tills vi flyttar till en databas
      
        public static IList<User> Users { get; private set; } = new List<User>();
        public UserRepositories()
        {
            if ( !Users.Any())
            {
                SetUserDataLogin();
            }
        }

        private void SetUserDataLogin()
        {
            Users = new List<User>
        {
            new User { Id = Guid.NewGuid(),  Email = "Admin@admin.com", UserN = "Admin", Pwd = "Admin@123",IsAdministrator = true, },
            new User { Id = Guid.NewGuid(), Email = "User1@user.com", UserN = "User1", Pwd = "Admin@123"  ,IsAdministrator = false,}
        };
        }

        public User checkUserOPWD(User use)
        {
            var user = Users.FirstOrDefault(x => x.UserN == use.UserN && x.Pwd == use.Pwd);
            return user;
        }
        public User GetByIdAsync(Guid id)
        {
            var find = Users.FirstOrDefault(u => u.Id == id);
            return find;
        }

        public List<User> SearchFor(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return (List<User>) Users;
        }

        public void EditAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public void InsertAsync(User entity)
        {
            Users.Add(entity);
        }

        public void DeleteAsync(Guid id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            Users.Remove(user);
        }
        
    }
}
