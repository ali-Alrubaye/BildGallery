using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayers.Models;
using Repositories;
using Repositories.Models;

namespace BusinessLayers.MapperClass
{
    public class PhotoAutomapper
    {
        PhotoRepository<Photo> _photoRepository = new PhotoRepository<Photo>(new BildGalleryContext());

        public List<PhotoViewModel> FromBltoUiGetAll()
        {
            var getData = _photoRepository.GetAll().ToList();
            var randomPhoto = Mapper.Map<List<Photo>, List<PhotoViewModel>>(getData);
            return randomPhoto;
        }
        //public List<PhotoViewModel> FromBltoUiGetAllByAlbumId(Guid id)
        //{
        //    var getData = _photoRepository.GetPhotoByAlbumId(id).ToList();
        //    var randomPhoto = Mapper.Map<List<Photo>, List<PhotoViewModel>>(getData);
        //    return randomPhoto;
        //}
        public async Task<PhotoViewModel> FromBltoUiGetById(Guid id)
        {
            var getRepo = await _photoRepository.GetByIdAsync(id);
            var detailsId = Mapper.Map<Photo, PhotoViewModel>(getRepo);
            return detailsId;
        }

        public async Task FromBltoUiInser(PhotoViewModel Photo)
        {
            var addMap = Mapper.Map<PhotoViewModel, Photo>(Photo);
            await _photoRepository.InsertAsync(addMap);
        }

        public async Task FromBltoUiEditAsync(PhotoViewModel Photo)
        {
            var editMap = Mapper.Map<PhotoViewModel, Photo>(Photo);
            await _photoRepository.EditAsync(editMap);
        }

        public async Task FromBltoUiDeleteAsync(Guid id)
        {
            var getFromR = await _photoRepository.GetByIdAsync(id);
            await _photoRepository.DeleteAsync(getFromR);
        }
    }
}
