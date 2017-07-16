using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Models;
using DatalagerTow.Models;
using DatalagerTow.Repositories;

namespace BusinessLayer.MapperClass
{
    public class CommentAutomapper
    {
        CommentRepository _commentRepository = new CommentRepository();

        public IEnumerable<CommentViewModel> FromBltoUiGetAll()
        {
            var getData = _commentRepository.GetAll().ToList();
            var randomComment = Mapper.Map<List<Comment>, IEnumerable<CommentViewModel>>(getData);
            return randomComment;
        }
        public List<CommentViewModel> FromBltoUiGetCommentByAlbumId(Guid id)
        {
            var getData = _commentRepository.GetCommentByAlbumId(id).ToList();
            var randomComment = Mapper.Map<List<Comment>, List<CommentViewModel>>(getData);
            return randomComment;
        }
        public CommentViewModel FromBltoUiGetById(Guid id)
        {
            var getRepo = _commentRepository.GetByIdAsync(id);
            var detailsId = Mapper.Map<Comment, CommentViewModel>(getRepo);
            return detailsId;
        }

        public void FromBltoUiInser(CommentViewModel Comment)
        {
            var addMap = Mapper.Map<CommentViewModel, Comment>(Comment);
            _commentRepository.InsertAsync(addMap);

        }

        public void FromBltoUiEditAsync(CommentViewModel Comment)
        {
            var editMap = Mapper.Map<CommentViewModel, Comment>(Comment);
            _commentRepository.EditAsync(editMap);

        }

        public void FromBltoUiDeleteAsync(Guid id)
        {
            var getFromR = _commentRepository.GetByIdAsync(id);
            _commentRepository.DeleteAsync(getFromR.Id);

        }
    }
}
