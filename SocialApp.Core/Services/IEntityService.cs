using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.Core.Models;

namespace SocialApp.Core.Services
{

    public interface IEntityService<T> where T : Entity
    {
        IQueryable<T> Query();
        IQueryable<T> QueryById(int id);
        IEnumerable<T> GetAllById(int id);
        IEnumerable<T> Get();
        Task<T> GetById(int id);
        IEnumerable<Post> GetAllByUserId(int userId);
        Task<User> GetUserByEmail(string email);
        ServiceResult Create(T entity);
        ServiceResult Delete(T entity);
        ServiceResult Update(T entity);
        bool Exists(int id);
    }
}
