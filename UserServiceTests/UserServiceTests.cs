using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialApp.Core;
using SocialApp.Core.Models;
using SocialApp.Core.Services;
using SocialApp.Service;

namespace UserServiceTests
{
    [TestClass]
    public class UserServiceTests
    {
        private IUserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService();
        }

        [TestMethod]
        public void AddScooterTest()
        {
            _userService.AddNewUser(
                new User() {Name = "Nora", Surname = "Kalva", 
                    BirthDate = "2001-12-12", Email = "nora@de.lv",
                    Password = "123", FriendRequest = false, Id = 12,
                    Post = null, Image = null, Interests = "", Online = false
                });
        }



    }
}
