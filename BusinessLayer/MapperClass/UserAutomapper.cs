using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Models;
using DatalagerTow.Models;
using DatalagerTow.Repositories;

namespace BusinessLayer.MapperClass
{
    public class UserAutomapper
    {
        UserRepositories _userRepositories = new UserRepositories();

        public IEnumerable<UserViewModel> FromBltoUiGetAll()
        {
            var getData = _userRepositories.GetAll().ToList();
            var randomUser = Mapper.Map<List<User>, IEnumerable<UserViewModel>>(getData);
            return randomUser;
        }

        public UserViewModel FromBltoUiGetById(Guid id)
        {
            var getRepo = _userRepositories.GetByIdAsync(id);
            var detailsId = Mapper.Map<User, UserViewModel>(getRepo);
            return detailsId;
        }

        public void FromBltoUiInser(UserViewModel user)
        {
            var addMap = Mapper.Map<UserViewModel, User>(user);
            _userRepositories.InsertAsync(addMap);

        }

        public void FromBltoUiEditAsync(UserViewModel user)
        {
            var editMap = Mapper.Map<UserViewModel, User>(user);
            _userRepositories.EditAsync(editMap);

        }

        public void FromBltoUiDeleteAsync(Guid id)
        {
            var getFromR = _userRepositories.GetByIdAsync(id);
            _userRepositories.DeleteAsync(getFromR.Id);

        }
        public UserViewModel FromBltoUiCheckUser(UserViewModel use)
        {
            var checkMap = Mapper.Map<UserViewModel, User>(use);
            var user = _userRepositories.checkUserOPWD(checkMap);
        
            var returnValue = Mapper.Map<User, UserViewModel>(user);
            return returnValue;
        }
    }
}
