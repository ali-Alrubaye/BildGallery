using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repositories.IRepositories;
using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetByIdAsync(Guid id)
        {
            using (var ctx = new BildGalleryContext())
            {
                var find = await ctx.Users.FindAsync(id);
                return find;
            }
        }

        public IQueryable<User> SearchFor(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            using (var ctx = new BildGalleryContext())
            {
                var getAll = ctx.Users;
                    //.Include(c => c.Comments)
                //.Include(p => p.Photos);
                return await getAll.ToListAsync();
            }
        }

        public async Task EditAsync(User entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }

        public async Task InsertAsync(User entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                ctx.Entry(entity).State = EntityState.Added;
                await ctx.SaveChangesAsync();
            }
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }


        public async Task<User> CheckUserOpwd(User entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                //var us = (from t in ctx.Users
                //    where t.UserN == entity.UserN
                //    select t).ToList().FirstOrDefault();
                var r = await ctx.Users.FirstOrDefaultAsync(x => x.UserN == entity.UserN);
                return r;
            }
        }
    }
}