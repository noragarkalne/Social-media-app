using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Core.Models;
using SocialApp.Core.Services;
using SocialApp.Data;
using SocialApp.Service.Exceptions;

namespace SocialApp.Service
{
    public class UserService : EntityService<User>, IUserService
    {

        public UserService(ISocialAppDbContext context) : base(context)
        {

        }

        public UserService()
        {

        }

        //public Task<IEnumerable<Post>> GetPosts()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ServiceResult> AddNewUser(User user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                throw new EmptyNameException();
            }

            if (string.IsNullOrEmpty(user.Surname))
            {
                throw new EmptySurNameException();
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new EmptyEmailException();
            }

            if (string.IsNullOrEmpty(user.BirthDate))
            {
                throw new EmptyBirthdayDateException();
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new EmptyPasswordException();
            }
            var users = await _ctx.Users.ToListAsync();

            if (users.Any(u => u.Email.Equals(user.Email)))
            {
                return new ServiceResult(false).Set($"User with this e-mail already exist!");
            }
            if (!user.Email.Contains("@"))
            {
                return new ServiceResult(false).Set($"E-mail should contain @ symbol!");
            }

            var date = DateTime.Parse(user.BirthDate);
            var age = GetAge(date);
            if (age < 13)
            {
                throw new UnderAgeException();
                //return new ServiceResult(false).Set($"To register on this site, you should be at least 13 years old, so go to your parents and ask for permision!!!");
            }
            if (age == -1)
            {
                throw new FutureDateBirthdayException();
                //return new ServiceResult(false).Set($"To register on this site, you should be at least 13 years old, so go to your parents and ask for permision!!!");
            }

            var hashPassword = EasyEncryption.MD5.ComputeMD5Hash(user.Password);
            return Create(new User
            {
                Name = user.Name,
                Surname = user.Surname,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Password = hashPassword,
                Interests = user.Interests,
                Image = user.Image,
                FriendRequest = user.FriendRequest,
                Online = user.Online,
                Post = user.Post
            });
        }

        public int GetAge(DateTime date)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - date.Year;
            if (date > today.AddYears(-age))
            {
                age--;
            }

            if(date > today)
            {
                return -1;
            }
            
            return age;
        }

        public async Task<ServiceResult> GetUser(string email, string password)
        {
            if (!email.Contains("@"))
            {
                return new ServiceResult(false).Set($"E-mail address should include '@'!");
            }

            if (email == "")
            {
                throw new EmptyEmailException();
            }

            if (password == "")
            {
                throw new EmptyPasswordException();
            }

            var user = await GetUserByEmail<User>(email);
            var hashedPassword = EasyEncryption.MD5.ComputeMD5Hash(password);
            
          
            if (user == null || user.Password != hashedPassword)
            {
                return new ServiceResult(false).Set($"Invalid username or password!");
            }
            var task = new ServiceResult(true).Set(user);
            return task;
        }

        public void ClearAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> RemoveUser(int userId)
        {
            var users = await _ctx.Users.ToListAsync();
            var user = users.SingleOrDefault(u => u.Id == userId);

            return Delete(user);
        }
    }
}
