using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialApp.Core.Models;
using SocialApp.Core.Services;
using SocialApp.Service;
using SocialApp.Service.Exceptions;

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
        public void AddNewUserTest()
        {
            _userService.AddNewUser(
                new User() {Name = "Nora", Surname = "Kalva", 
                    BirthDate = "2001-12-12", Email = "nora@de.lv",
                    Password = "123", FriendRequest = false, Id = 12,
                    Post = null, Image = null, Interests = "", Online = false
                });
        }

        [TestMethod]
        public void AddNewUserWithoutNameTest()
        {
            var user = new User
            {
                Name = "",
                Surname = "Kalva",
                BirthDate = "2001-12-12",
                Email = "nora@de.lv",
                Password = "123",
                FriendRequest = false,
                Id = 12,
                Post = null,
                Image = null,
                Interests = "",
                Online = false
            };

            Assert.ThrowsException<EmptyNameException>(() => 
                _userService.AddNewUser(user));
           
        }





    }
}
