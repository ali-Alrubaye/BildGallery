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
    public class CommentRepository : ICommentRepository
    {
       
        public CommentRepository()
        {
        }

        public async Task<List<Comment>> GetAll()
        {
            using (var ctx = new BildGalleryContext())
            {
                var p = ctx.Comments
                    .ToListAsync();
                return await p;
            }
        }


        public async Task<Comment> GetByIdAsync(Guid id)
        {
            using (var ctx = new BildGalleryContext())
            {
                var find = ctx.Comments.Where(p => p.Id == id)
                        .FirstOrDefaultAsync();
                return await find;
            }

        }
        public IQueryable<Comment> SearchFor(Expression<Func<Comment, bool>> predicate)
        {
            using (var ctx = new BildGalleryContext())
            {
                return ctx.Comments.Where(predicate);
            }
        }

        public async Task EditAsync(Comment entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }

        public async Task InsertAsync(Comment entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                var insertComm = new Comment();
                insertComm.Id = entity.Id;
                insertComm.AlbumId = entity.AlbumId;
                insertComm.UserId = entity.UserId;
                insertComm.PhotoId = entity.PhotoId;
                insertComm.Content = entity.Content;
                insertComm.Date = entity.Date;
                ctx.Comments.Add(insertComm);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Comment entity)
        {
            using (var ctx = new BildGalleryContext())
            {
                ctx.Comments.Remove(entity);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
