using System;
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

            Assert.ThrowsExceptionAsync<EmptyNameException>(() => 
                _userService.AddNewUser(user));
           
        }

        [TestMethod]
        public void AddNewUserWithoutSurNameTest()
        {
            var user = new User
            {
                Name = "Nora",
                Surname = "",
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

            Assert.ThrowsExceptionAsync<EmptySurNameException>(() =>
                _userService.AddNewUser(user));

        }

        [TestMethod]
        public void AddNewUserWithoutBirthdayTest()
        {
            var user = new User
            {
                Name = "Nora",
                Surname = "Kalva",
                BirthDate = "",
                Email = "nora@de.lv",
                Password = "123",
                FriendRequest = false,
                Id = 12,
                Post = null,
                Image = null,
                Interests = "",
                Online = false
            };

            Assert.ThrowsExceptionAsync<EmptyBirthdayDateException>(() =>
                _userService.AddNewUser(user));

        }
        [TestMethod]
        public void CheckNewUserIsUnderAge()
        {
            var user = new User
            {
                Name = "Nora",
                Surname = "Kalva",
                BirthDate = "2009-12-12",
                Email = "nora@de.lv",
                Password = "123",
                FriendRequest = false,
                Id = 12,
                Post = null,
                Image = null,
                Interests = "",
                Online = false
            };
            var date = DateTime.Parse(user.BirthDate);
            var age = GetAge(date);
            if (age < 13)
            {
                Assert.ThrowsExceptionAsync<UnderAgeException>(() =>
                    _userService.AddNewUser(user));
            }
        }

        [TestMethod]
        public void CheckNewUserBirthdayIsNotInFuture()
        {
            var user = new User
            {
                Name = "Nora",
                Surname = "Kalva",
                BirthDate = "2029-12-12",
                Email = "nora@de.lv",
                Password = "123",
                FriendRequest = false,
                Id = 12,
                Post = null,
                Image = null,
                Interests = "",
                Online = false
            };
            var date = DateTime.Parse(user.BirthDate);
            var age = GetAge(date);
            if (age == -1)
            {
                Assert.ThrowsExceptionAsync<FutureDateBirthdayException> (() =>
                    _userService.AddNewUser(user));
            }
        }
        public int GetAge(DateTime date)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - date.Year;
            if (date > today.AddYears(-age))
            {
                age--;
            }
            if (date < today.AddYears(-age))
            {
                age = -1;
            }

            return age;
        }

        [TestMethod]
        public void CheckEmailIsNotNullOrEmptyTest()
        {
            var user = new User
            {
                Name = "Nora",
                Surname = "Kalva",
                BirthDate = "2001-12-12",
                Email = "",
                Password = "123",
                FriendRequest = false,
                Id = 12,
                Post = null,
                Image = null,
                Interests = "",
                Online = false
            };

            Assert.ThrowsExceptionAsync<EmptyEmailException>(() =>
                _userService.AddNewUser(user));

        }

        [TestMethod]
        public void RegisterWithoutPassword()
        {
            var user = new User
            {
                Name = "Nora",
                Surname = "Kalva",
                BirthDate = "2001-12-12",
                Email = "nora@de.lv",
                Password = "",
                FriendRequest = false,
                Id = 12,
                Post = null,
                Image = null,
                Interests = "",
                Online = false
            };

            Assert.ThrowsExceptionAsync<EmptyPasswordException>(() =>
                _userService.AddNewUser(user));

        }

        [TestMethod]
        public void LoginWithoutEmail()
        {
            var user = new User
            {
                Email = "",
                Password = "123"
            };

            Assert.ThrowsExceptionAsync<EmptyEmailException>(() =>
                _userService.GetUser(user.Email, user.Password));

        }

        [TestMethod]
        public void LoginWithoutPassword()
        {
            var user = new User
            {
                Email = "nora@de.lv",
                Password = ""
            };

            Assert.ThrowsExceptionAsync<EmptyPasswordException>(() =>
                _userService.GetUser(user.Email, user.Password));

        }




    }
}
