using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialApp.Core.Services.Interfaces;
using TutorialApp.Datalayer.Context;

namespace TutorialApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly TutorialAppContext _Contex;
        public UserService(TutorialAppContext context)
        {
            _Contex = context;
        }


        public bool IsEmailExist(string email)
        {
            return _Contex.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return _Contex.Users.Any(u => u.Username == username);
        }
    }
}
