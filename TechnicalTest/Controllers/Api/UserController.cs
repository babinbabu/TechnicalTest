using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechnicalTest.Models;
using TechnicalTest.Services;
using TechnicalTest.WebApi;

namespace TechnicalTest.Controllers.Api
{
    public class UserController : ApiController
    {

        [HttpGet]
        public List<UserModel> UserList(string searchString,UserSortType sortType = UserSortType.EmailAsc, int take = 15, int skip = 0)
        {
            return WebApiWrapper.Call<List<UserModel>>(e => UserControlService.UserList(searchString, sortType, take, skip));
        }
        [HttpPost]
        public UserIdResult UserCreate(UserModel model)
        {
            return WebApiWrapper.Call<UserIdResult>(e => UserControlService.Create(model));
        }
        [HttpPut]
        public UserModel UserUpdate(long userId, UserModel model)
        {
            return WebApiWrapper.Call<UserModel>(e => UserControlService.Update(userId, model));
        }
        [HttpDelete]
        public BoolResult UserDelete(long userId)
        {
            return WebApiWrapper.Call<BoolResult>(e => UserControlService.Delete(userId));
        }
    }
}
