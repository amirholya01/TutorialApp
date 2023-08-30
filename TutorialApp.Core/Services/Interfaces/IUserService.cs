﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUsernameExist(string username);
        bool IsEmailExist(string email);
    }
}