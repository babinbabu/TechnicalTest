using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnicalTest.Models;
using TechnicalTest.WebApi;

namespace TechnicalTest.Services
{
    public class UserControlService
    {
        public static List<UserModel> UserList(string searchString, UserSortType sortType = UserSortType.EmailAsc, int take = 15, int skip = 0)
        {
            using (Entity.TechnicalTestEntities db = new Entity.TechnicalTestEntities())
            {
                IQueryable<Entity.User> Users = db.Users;
                if (!string.IsNullOrEmpty(searchString))
                {
                    Users = db.Users.Where(e => e.Email.ToLower().Contains(searchString.ToLower()) || e.Phone.ToLower().Contains(searchString.ToLower()));
                }

                switch (sortType)
                {
                    case UserSortType.EmailAsc:
                        Users = Users.OrderBy(e => e.Email);
                        break;
                    case UserSortType.EmailDsc:
                        Users = Users.OrderByDescending(e => e.Email);
                        break;
                    case UserSortType.PhoneAsc:
                        Users = Users.OrderBy(e => e.Phone);
                        break;
                    case UserSortType.PhoneDsc:
                        Users = Users.OrderByDescending(e => e.Phone);
                        break;
                    default:
                        Users = Users.OrderBy(e => e.Email);
                        break;
                }
                Users = Users.Skip(skip).Take(take);
                List<UserModel> result = new List<UserModel>();
                foreach (var User in Users)
                {
                    result.Add(new UserModel(User));
                }

                return result;
            }
        }

        public static UserIdResult Create(UserModel model)
        {
            model.Validate();
            using (Entity.TechnicalTestEntities db = new Entity.TechnicalTestEntities())
            {
                var entityUser = db.Users.Create();
                entityUser.FullName = model.FullName;
                entityUser.Email = model.Email;
                entityUser.Phone = model.Phone;
                entityUser.Age = model.Age;

                db.Users.Add(entityUser);

                db.SaveChanges();

                return new UserIdResult(entityUser.UserId);
            }
        }

        public static UserModel Update(long userId, UserModel model)
        {
            model.Validate();
            using (Entity.TechnicalTestEntities db = new Entity.TechnicalTestEntities())
            {
                var entityUser = db.Users.FirstOrDefault(e => e.UserId == userId);

                if(entityUser ==null)
                {
                    throw new WebApiException(
                   new WebApiError(WebApiErrorCode.InvalidArguments, "User Id not found"));
                }

                entityUser.FullName = model.FullName;
                entityUser.Email = model.Email;
                entityUser.Phone = model.Phone;
                entityUser.Age = model.Age;

                db.SaveChanges();

                return new UserModel(entityUser);
            }
        }

        public static BoolResult Delete(long userId)
        {
            using (Entity.TechnicalTestEntities db = new Entity.TechnicalTestEntities())
            {
                var entityUser = db.Users.FirstOrDefault(e => e.UserId == userId);

                if (entityUser != null)
                {
                    db.Users.Remove(entityUser);
                    db.SaveChanges();
                    return new BoolResult(true);
                }

                return new BoolResult(false);
            }
        }
    }
}