using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repositories.IRepositories;
using Repositories.Models;
using System.Collections.Generic;

namespace Repositories
{
    public class PhotoRepository : IPhotoRepository
    {


        public async Task<List<Photo>> GetAll()
        {
            using (var ctx = new BildGalleryContext())
            {
                var p = ctx.Photos
                    .Include(a => a.Album)
                    .ToListAsync();
                return await p;
            }
        }

        public async Task<Photo> GetByIdAsync(Guid id)
        {
            using (var ctx = new BildGalleryContext())
            {
                var find = ctx.Photos.Where(p => p.PhotoId == id)
                        .Include(p => p.Album)
                        .Include(p => p.Comments)
                        .FirstOrDefaultAsync();
                return await find;
            }
        }

        public IQueryable<Photo> SearchFor(Expression<Func<Photo, bool>> predicate)
        {
            using (var ctx = new BildGalleryContext())
            {
                return ctx.Photos.Where(predicate);
            }

        }

        public async Task EditoUpdateAsync(Photo entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                var updatePhoto = ctx.Photos.Where(p => p.PhotoId == entity.PhotoId)
                        .Include(p => p.Comments)
                        .Include(p => p.Album)
                        .FirstOrDefault();
                if (updatePhoto != null)
                {
                    updatePhoto.AlbumId = entity.AlbumId;
                    updatePhoto.PhotoId = entity.PhotoId;
                    updatePhoto.PhotoDate = entity.PhotoDate;
                    updatePhoto.PhotoName = entity.PhotoName;
                    updatePhoto.PhotoPath = entity.PhotoPath;
                    updatePhoto.Description = entity.Description;
                }
                await ctx.SaveChangesAsync();
            }
        }

        public async Task InsertAsync(Photo entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                var addPhoto = new Photo();
                addPhoto.AlbumId = entity.AlbumId;
                addPhoto.PhotoId = entity.PhotoId;
                addPhoto.PhotoDate = entity.PhotoDate;
                addPhoto.PhotoName = entity.PhotoName;
                addPhoto.PhotoPath = entity.PhotoPath;
                addPhoto.Description = entity.Description;
                ctx.Photos.Add(addPhoto);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                var p = ctx.Photos.FirstOrDefault(x => x.PhotoId == entity);
                ctx.Photos.Remove(p);
                await ctx.SaveChangesAsync();
            }
        }
        public async Task<List<Photo>> GetPhotoByAlbumIdAsync(Guid id)
        {
            using (var ctx = new BildGalleryContext())
            {
                var find = ctx.Photos.Where(p => p.AlbumId == id)
                        //.Include(p => p.User)
                        //.Include(p => p.Comments)                        
                        .ToListAsync();
                return await find;
            }
        }
    }
}
