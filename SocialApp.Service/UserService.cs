using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.Core.Models;
using SocialApp.Core.Services;
using SocialApp.Data;

namespace SocialApp.Service
{
    public class UserService : EntityService<User>, IUserService
    {

        public UserService(ISocialAppDbContext context) : base(context)
        {

        }

        public Task<IEnumerable<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> AddNewUser(User user)
        {
            var users = await _ctx.Users.ToListAsync();

            if (users.Any(u => u.Email.Equals(user.Email)))
            {
                return new ServiceResult(false);
            }

            return Create(user);
        }

        public async Task<ServiceResult> GetUser(string email)
        {
            var users = await _ctx.Users.ToListAsync();
            var user = users.SingleOrDefault(u => u.Email == email);

            if (user == null)
            {
                return new ServiceResult(false);
            }

            return new ServiceResult(true).Set(user);
        }

        public void ClearAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
