using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
        public class AlbumAutomapper
        {
            //AlbumRepository<Album> _albumRepository = new AlbumRepository<Album>(new BildGalleryContext());
            AlbumRepository _albumRepository = new AlbumRepository();

            public List<AlbumViewModel> FromBltoUiGetAll()
            {
                var getData = _albumRepository.GetAll().ToList();
            var randomAlbum = Mapper.Map<List<Album>, List<AlbumViewModel>>(getData);
            return randomAlbum;
            }

            public AlbumViewModel FromBltoUiGetById(Guid id)
            {
                var getRepo =  _albumRepository.GetByIdAsync(id);
                var detailsId = Mapper.Map<Album, AlbumViewModel>(getRepo);
                return detailsId;
            }

            public void FromBltoUiInser(AlbumViewModel album)
            {
                var addMap = Mapper.Map<AlbumViewModel, Album>(album);
                 _albumRepository.InsertAsync(addMap);

            }

            public void FromBltoUiEditAsync(AlbumViewModel album)
            {
                var editMap = Mapper.Map<AlbumViewModel, Album>(album);
                 _albumRepository.EditAsync(editMap);

            }

            public void FromBltoUiDeleteAsync(Guid id)
            {
                var getFromR =  _albumRepository.GetByIdAsync(id);
                 _albumRepository.DeleteAsync(getFromR.AlbumId);

            }
        }
}

