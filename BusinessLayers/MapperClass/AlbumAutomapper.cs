using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Repositories;
using Repositories.Models;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
        public class AlbumAutomapper
        {
        AlbumRepository<Album> _albumRepository = new AlbumRepository<Album>(new BildGalleryContext());

        public IEnumerable<AlbumViewModel> FromBltoUiGetAll()
        {
            var getData = _albumRepository.GetAll().ToList();
            var randomAlbum = Mapper.Map<List<Album>, IEnumerable<AlbumViewModel>>(getData);
            return randomAlbum;
        }

        public async Task<AlbumViewModel> FromBltoUiGetById(Guid id)
        {
            var getRepo = await _albumRepository.GetByIdAsync(id);
            var detailsId = Mapper.Map<Album, AlbumViewModel>(getRepo);
            return detailsId;
        }

        public async Task FromBltoUiInser(AlbumViewModel album)
        {
            var addMap = Mapper.Map<AlbumViewModel, Album>(album);
            await _albumRepository.InsertAsync(addMap);

        }

        public async Task FromBltoUiEditAsync(AlbumViewModel album)
        {
            var editMap = Mapper.Map<AlbumViewModel, Album>(album);
            await _albumRepository.EditAsync(editMap);

        }

        public async Task FromBltoUiDeleteAsync(Guid id)
        {
            var getFromR = await _albumRepository.GetByIdAsync(id);
            await _albumRepository.DeleteAsync(getFromR);

        }
    }
}

