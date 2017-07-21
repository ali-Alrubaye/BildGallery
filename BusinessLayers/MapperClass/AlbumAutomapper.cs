using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayers.Models;
using Repositories;
using Repositories.Models;
using BusinessLayers.AutoMapper;
using AutoMapper;

namespace BusinessLayers.MapperClass
{
    public class AlbumAutomapper
    {
        public AlbumAutomapper()
        {
            _albumRepository = new AlbumRepository();
            _photo = new PhotoRepository();
        }

        //private readonly AlbumRepository _albumRepository = new AlbumRepository();
        public AlbumRepository _albumRepository { get; set; }
        public PhotoRepository _photo { get; set; }

        public IEnumerable<AlbumViewModel> FromBltoUiGetAll()
        {
            //var list = new List<AlbumViewModel>();
            var getData =  _albumRepository.GetAll();
            var randomAlbum = Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumViewModel>>(getData);
            //foreach (var item in getData)
            //{
            //    var randomAlbum = ModelMapper.DbToModelAlb(item);
            //    list.Add(randomAlbum);
            //}
            return randomAlbum;
        }

        public async Task<AlbumViewModel> FromBltoUiGetById(Guid id)
        {
            var getRepo = await _albumRepository.GetByIdAsync(id);
            var randomAlbum = Mapper.Map<Album, AlbumViewModel>(getRepo);
            return randomAlbum;
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
            //var getFromR =await _albumRepository.GetByIdAsync(id);
            await _albumRepository.DeleteAsync(id);
        }
    }
}