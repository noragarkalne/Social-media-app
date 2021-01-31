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


        public Task<IEnumerable<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> AddNewUser(User user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                throw new EmptyNameException();
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
                return new ServiceResult(false).Set($"To register on this site, you should be at least 13 years old, so go to your parents and ask for permision!!!");
            }

            return Create(user);
        }

        public int GetAge(DateTime date)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - date.Year;
            if (date > today.AddYears(-age))
                age--;

            return age;
        }

        public async Task<ServiceResult> GetUser(string email, string password)
        {
            var users = await _ctx.Users.ToListAsync();
            var user = users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (!email.Contains("@"))
            {
                return new ServiceResult(false).Set($"E-mail address should include '@'!");
            }

            if (email == "" || password == "")
            {
                return new ServiceResult(false).Set($"Please fill in both fields!");
            }

            if (user == null)
            {
                return new ServiceResult(false).Set($"Invalid username or password!");
            }

            var x = new ServiceResult(true).Set(user);
            return x;
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
