using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datalagers.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public CommentRepository()
        {
            if (!Comments.Any())
                SetupTemporaryUserData();
        }

        // Spara i minnet tills vi flyttar till en databas
        public static IList<Comment> Comments { get; private set; } = new List<Comment>();

        public Comment GetByIdAsync(Guid id)
        {
            var com = Comments.FirstOrDefault(c => c.Id == id);
            return com;
        }

        public List<Comment> SearchFor(Expression<Func<Comment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            return Comments.ToList();
        }

        public void EditAsync(Comment comment)
        {
            var com = Comments.FirstOrDefault(c => c.Id == comment.Id);
        }

        public void InsertAsync(Comment comment)
        {
            Comments.Add(comment);
        }

        public void DeleteAsync(Guid id)
        {
            var com = Comments.FirstOrDefault(c => c.Id == id);
            Comments.Remove(com);
        }

        private void SetupTemporaryUserData()
        {
            var user = new UserRepositories();
            var u = user.GetAll();

            var photo = new PhotoRepository();
            var p = photo.GetAll();
            var album = new AlbumRepository();
            var a = album.GetAll();
            Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "Album01",
                    Date = DateTime.UtcNow,
                    UserId = u[0].Id,
                    PhotoId = null,
                    AlbumId = a[0].AlbumId
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "img01",
                    Date = DateTime.UtcNow,
                    UserId = u[1].Id,
                    PhotoId = p[0].PhotoId,
                    AlbumId = null
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "Album02",
                    Date = DateTime.UtcNow,
                    UserId = u[0].Id,
                    PhotoId = null,
                    AlbumId = a[1].AlbumId
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "img02",
                    Date = DateTime.UtcNow,
                    UserId = u[1].Id,
                    PhotoId = p[1].PhotoId,
                    AlbumId = null
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "img03",
                    Date = DateTime.UtcNow,
                    UserId = u[0].Id,
                    PhotoId = p[0].PhotoId,
                    AlbumId = null
                }
            };
        }

        public List<Comment> GetCommentByAlbumId(Guid id)
        {
            var find = Comments.Where(p => p.AlbumId == id).ToList();
            return find;
        }
    }
}
