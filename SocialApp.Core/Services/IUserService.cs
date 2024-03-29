﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.Core.Models;

namespace SocialApp.Core.Services
{
    public interface IUserService
    {
        Task<ServiceResult> AddNewUser(User user);
        Task<ServiceResult> GetUser(string email, string password);
        void ClearAllUsers();
        Task<ServiceResult> RemoveUser(int userId);
    }
}
