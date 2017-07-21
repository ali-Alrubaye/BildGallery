using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayers.Models;
using Repositories;
using Repositories.Models;
using BusinessLayers.AutoMapper;
using AutoMapper;

namespace BusinessLayers.MapperClass
{
    public class CommentAutomapper
    {
       
        //CommentRepository<Comment> _commentRepository = new CommentRepository<Comment>(new BildGalleryContext());
        private CommentRepository _commentRepository { get; set; }
        public CommentAutomapper()
        {
            _commentRepository = new CommentRepository();
        }
        public async Task<List<CommentViewModel>> FromBltoUiGetAll()
        {
            var getData = await _commentRepository.GetAll();
            var randomComment = Mapper.Map<List<Comment>, List<CommentViewModel>>(getData);
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
