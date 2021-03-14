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
    public class DbService : IDbService
    {
        protected readonly ISocialAppDbContext _ctx;

        public DbService(ISocialAppDbContext context)
        {
            _ctx = context;
        }

        public DbService()
        {

        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _ctx.Set<T>().AsQueryable();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return _ctx.Set<T>().Where(e => e.Id == id);
        }

        public IQueryable<T> QueryByUserId<T>(int userId) where T : Post
        {
            return _ctx.Set<T>().Where(e => e.UserId == userId);
        }

        public async Task<T> GetUserByEmail<T>(string email) where T : User
        {
            return await _ctx.Set<T>().SingleOrDefaultAsync(e => e.Email == email); 
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return Query<T>().ToList();
        }

        public async Task<T> GetById<T>(int id) where T : Entity
        {
            return await _ctx.Set<T>().SingleOrDefaultAsync(e => e.Id == id); //ASYNC and AWAIT always with SingleOrDefault
        }
        public IEnumerable<T> GetAllById<T>(int id) where T : Entity
        {
            return QueryById<T>(id).ToList();
        }

        public IEnumerable<T> GetAllByUserId<T>(int userId) where T : Post
        {
            return QueryByUserId<T>(userId).ToList();
        }

        public async Task<ServiceResult> Create<T>(T entity) where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

             _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();

            return new ServiceResult(true).Set(entity);
        }

        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            _ctx.Set<T>().Remove(entity); //Set shows which table to take
            _ctx.SaveChanges();
            return new ServiceResult(true);
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);

        }

        public bool Exists<T>(int id) where T : Entity
        {
            return QueryById<T>(id).Any();
        }
    }
}
