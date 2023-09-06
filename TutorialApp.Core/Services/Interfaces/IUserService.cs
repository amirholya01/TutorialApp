using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialApp.Core.DTOs;
using TutorialApp.Datalayer.Entities.User;

namespace TutorialApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUsernameExist(string username);
        bool IsEmailExist(string email);
        long AddUser(User user);
        User LoginUser(LoginViewModel loginViewModel);
        bool ActiveAccount(string avtiveCode);


        #region Admin-Panel
        UsersForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUsername ="");
        #endregion
    }
}
