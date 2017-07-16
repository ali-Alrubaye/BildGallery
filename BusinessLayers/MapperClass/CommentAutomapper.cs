using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayers.Models;
using Repositories;
using Repositories.Models;

namespace BusinessLayers.MapperClass
{
    public class CommentAutomapper
    {
       
        CommentRepository<Comment> _commentRepository = new CommentRepository<Comment>(new BildGalleryContext());

        public IEnumerable<CommentViewModel> FromBltoUiGetAll()
        {
            var getData = _commentRepository.GetAll().ToList();
            var randomComment = Mapper.Map<List<Comment>, IEnumerable<CommentViewModel>>(getData);
            return randomComment;
        }
        //public List<CommentViewModel> FromBltoUiGetCommentByAlbumId(Guid id)
        //{
        //    var getData = _commentRepository.GetCommentByAlbumId(id).ToList();
        //    var randomComment = Mapper.Map<List<Comment>, List<CommentViewModel>>(getData);
        //    return randomComment;
        //}
        public async Task<CommentViewModel> FromBltoUiGetById(Guid id)
        {
            var getRepo = await _commentRepository.GetByIdAsync(id);
            var detailsId = Mapper.Map<Comment, CommentViewModel>(getRepo);
            return detailsId;
        }

        public async Task FromBltoUiInser(CommentViewModel Comment)
        {
            var addMap = Mapper.Map<CommentViewModel, Comment>(Comment);
           await _commentRepository.InsertAsync(addMap);

        }

        public async Task FromBltoUiEditAsync(CommentViewModel Comment)
        {
            var editMap = Mapper.Map<CommentViewModel, Comment>(Comment);
           await _commentRepository.EditAsync(editMap);

        }

        public async Task FromBltoUiDeleteAsync(Guid id)
        {
            var getFromR = await _commentRepository.GetByIdAsync(id);
           await _commentRepository.DeleteAsync(getFromR);

        }
    }
}
