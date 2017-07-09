using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Models;
using DatalagerTow.Models;
using DatalagerTow.Repositories;

namespace BusinessLayer.MapperClass
{
    public class PhotoAutomapper
    {
        PhotoRepository _photoRepository = new PhotoRepository();

        public List<PhotoViewModel> FromBltoUiGetAll()
        {
            var getData = _photoRepository.GetAll().ToList();
            var randomPhoto = Mapper.Map<List<Photo>, List<PhotoViewModel>>(getData);
            return randomPhoto;
        }
        public List<PhotoViewModel> FromBltoUiGetAllByAlbumId(Guid id)
        {
            var getData = _photoRepository.GetPhotoByAlbumId(id).ToList();
            var randomPhoto = Mapper.Map<List<Photo>, List<PhotoViewModel>>(getData);
            return randomPhoto;
        }
        public PhotoViewModel FromBltoUiGetById(Guid id)
        {
            var getRepo = _photoRepository.GetByIdAsync(id);
            var detailsId = Mapper.Map<Photo, PhotoViewModel>(getRepo);
            return detailsId;
        }

        public void FromBltoUiInser(PhotoViewModel Photo)
        {
            var addMap = Mapper.Map<PhotoViewModel, Photo>(Photo);
            _photoRepository.InsertAsync(addMap);

        }

        public void FromBltoUiEditAsync(PhotoViewModel Photo)
        {
            var editMap = Mapper.Map<PhotoViewModel, Photo>(Photo);
            _photoRepository.EditAsync(editMap);

        }

        public void FromBltoUiDeleteAsync(Guid id)
        {
            var getFromR = _photoRepository.GetByIdAsync(id);
            _photoRepository.DeleteAsync(getFromR.PhotoId);

        }
    }
}
