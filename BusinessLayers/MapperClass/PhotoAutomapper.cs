using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayers.Models;
using Repositories;
using Repositories.Models;
using BusinessLayers.AutoMapper;
using AutoMapper;

namespace BusinessLayers.MapperClass
{
    public class PhotoAutomapper
    {
        //PhotoRepository<Photo> _photoRepository = new PhotoRepository<Photo>(new BildGalleryContext());
        public PhotoRepository _photoRepository { get; set; }
        public PhotoAutomapper()
        {
            _photoRepository = new PhotoRepository();
        }

        public async Task<IEnumerable<PhotoViewModel>> FromBltoUiGetAll()
        {
            var getData = await _photoRepository.GetAll();
            var getPhoto = Mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoViewModel>>(getData);
            return getPhoto;
        }
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

        public async Task FromBltoUiEditoUpdateAsync(PhotoViewModel Photo)
        {
            var editMap = Mapper.Map<PhotoViewModel, Photo>(Photo);
            await _photoRepository.EditoUpdateAsync(editMap);
        }

        public async Task FromBltoUiDeleteAsync(Guid id)
        {
            //var getFromR = await _photoRepository.GetByIdAsync(id);
            await _photoRepository.DeleteAsync(id);
        }
    }
}
