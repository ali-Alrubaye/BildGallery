using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayers.Models;
using Repositories;
using Repositories.Models;
using Repositories.Repositories;

namespace BusinessLayers.MapperClass
{
    public class UserAutomapper
    {
        UserRepository<User> _userRepositories = new UserRepository<User>(new BildGalleryContext());

        public IEnumerable<UserViewModel> FromBltoUiGetAll()
        {
            var getData = _userRepositories.GetAll().ToList();
            var randomUser = Mapper.Map<List<User>, IEnumerable<UserViewModel>>(getData);
            return randomUser;
        }

        public async Task<UserViewModel> FromBltoUiGetById(Guid id)
        {
            var getRepo = await _userRepositories.GetByIdAsync(id);
            var detailsId = Mapper.Map<User, UserViewModel>(getRepo);
            return detailsId;
        }

        public async Task FromBltoUiInser(UserViewModel user)
        {
            var addMap = Mapper.Map<UserViewModel, User>(user);
           await _userRepositories.InsertAsync(addMap);

        }

        public async Task FromBltoUiEditAsync(UserViewModel user)
        {
            var editMap = Mapper.Map<UserViewModel, User>(user);
           await _userRepositories.EditAsync(editMap);

        }

        public async Task FromBltoUiDeleteAsync(Guid id)
        {
            var getFromR = await _userRepositories.GetByIdAsync(id);
             _userRepositories.DeleteAsync(getFromR);

        }
        //public async Task<UserViewModel> FromBltoUiCheckUser(UserViewModel use)
        //{
        //    var checkMap = Mapper.Map<UserViewModel, User>(use);
        //    var user = await _userRepositories.checkUserOPWD(checkMap);
        
        //    var returnValue = Mapper.Map<User, UserViewModel>(user);
        //    return returnValue;
        //}
    }
}
