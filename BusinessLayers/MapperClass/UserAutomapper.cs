using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayers.Models;
using Repositories.Models;
using Repositories.Repositories;
using BusinessLayers.AutoMapper;
using AutoMapper;

namespace BusinessLayers.MapperClass
{
    public class UserAutomapper
    {
        private readonly UserRepository _userRepositories;
        public UserAutomapper()
        {
            _userRepositories = new UserRepository();
        }

        public async Task<List<UserViewModel>> FromBltoUiGetAll()
        {
            var getData = await _userRepositories.GetAll();
            var randomUser = Mapper.Map<List<User>, List<UserViewModel>>(getData);
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
            await _userRepositories.DeleteAsync(getFromR);
        }

        public async Task<UserViewModel> FromBlotUiCheckUser(UserViewModel use)
        {
            var checkMap = Mapper.Map<UserViewModel, User>(use);
            var user = await _userRepositories.CheckUserOpwd(checkMap);

            var returnValue = Mapper.Map<User, UserViewModel>(user);
            return returnValue;
        }
    }
}