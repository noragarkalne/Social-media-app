using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.Core.Models;

namespace SocialApp.Core.Services
{
    public interface IDbService
    {
        IQueryable<T> Query<T>() where T : Entity;
        IQueryable<T> QueryById<T>(int id) where T : Entity;
        IEnumerable<T> Get<T>() where T : Entity;
        Task<T> GetById<T>(int id) where T : Entity;
        IEnumerable<T> GetAllById<T>(int id) where T : Entity;
        IEnumerable<T> GetAllByUserId<T>(int userId) where T : Post;
        Task<T> GetUserByEmail<T>(string email) where T : User;
        Task<ServiceResult> Create<T>(T entity) where T : Entity;
        ServiceResult Delete<T>(T entity) where T : Entity;
        ServiceResult Update<T>(T entity) where T : Entity;
        bool Exists<T>(int id) where T : Entity;
    }
}
