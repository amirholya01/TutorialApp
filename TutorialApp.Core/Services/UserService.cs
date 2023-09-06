using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialApp.Core.Convertors;
using TutorialApp.Core.DTOs;
using TutorialApp.Core.Security;
using TutorialApp.Core.Services.Interfaces;
using TutorialApp.Core.Utils;
using TutorialApp.Datalayer.Context;
using TutorialApp.Datalayer.Entities.User;

namespace TutorialApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly TutorialAppContext _Contex;
        public UserService(TutorialAppContext context)
        {
            _Contex = context;
        }

        public bool ActiveAccount(string avtiveCode)
        {
            var user = _Contex.Users.SingleOrDefault(u => u.ActiveCode == avtiveCode);
            if(user == null || user.IsActive)
                return false;
            user.IsActive = true;
            user.ActiveCode = CodeGenerator.stringCodeGenerator();
            _Contex.SaveChanges();
            return true;
        }

        public long AddUser(User user)
        {
            _Contex.Users.Add(user);
            _Contex.SaveChanges();
            return user.UserId;
        }

        public UsersForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUsername = "")
        {
            IQueryable<User> result = _Contex.Users;

            if(!string.IsNullOrEmpty(filterEmail))
                result = result.Where(u => u.Email.Contains(filterEmail));
            if(!string.IsNullOrEmpty(filterUsername))
                result = result.Where(u => u.Username.Contains(filterUsername));

            int take = 20;
            int skip = (pageId - 1) * take;

            UsersForAdminViewModel list = new UsersForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            return list;
        }

        public bool IsEmailExist(string email)
        {
            return _Contex.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return _Contex.Users.Any(u => u.Username == username);
        }

        public User LoginUser(LoginViewModel loginViewModel)
        {
            string hashPassword = HashString.hashString(loginViewModel.Password);
            string email = InputConvertors.EmailValidator(loginViewModel.Email);
            return _Contex.Users.SingleOrDefault(u => u.Email == email && u.Password == hashPassword);
        }
    }
}
