using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repositories.IRepositories;
using Repositories.Models;

namespace Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public IEnumerable<Album> GetAll()
        {
            using (var ctx = new BildGalleryContext())
            {
                var getAll = ctx.Albums
                    //.Include(u => u.User)
                    .Include(c => c.Comments)
                    .Include(p => p.Photos);
                return  getAll.ToList();
            }
        }

        public async Task<Album> GetByIdAsync(Guid id)
        {
            using (var ctx = new BildGalleryContext())
            {
                //var find = (from t in ctx.Albums
                //            where t.AlbumId == id
                //            select t).FirstOrDefaultAsync();
                var find = ctx.Albums.Where(p => p.AlbumId == id)
                        //.Include(p => p.User)
                        .Include(p => p.Comments)
                        .Include(p => p.Photos)
                        .FirstOrDefaultAsync();

                return await find;
            }
        }

        public IQueryable<Album> SearchFor(Expression<Func<Album, bool>> predicate)
        {
            using (var ctx = new BildGalleryContext())
            {
                var find = ctx.Albums.Where(predicate);
                return find;
            }
        }

        public async Task EditAsync(Album entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                var EA = ctx.Albums.FirstOrDefault(x => x.AlbumId == entity.AlbumId);
                //EA.AlbumId = entity.AlbumId;
                EA.AlbumName = entity.AlbumName;
                EA.AlbumDate = entity.AlbumDate;
                EA.Description = entity.Description;
                
                //ctx.Entry<Album>(entity).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }

        public async Task InsertAsync(Album entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                ctx.Entry(entity).State = EntityState.Added;
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                var p = ctx.Albums.FirstOrDefault(x => x.AlbumId == entity);
                ctx.Albums.Remove(p);
                await ctx.SaveChangesAsync();
            }
        }
    }
}