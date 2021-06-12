using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.Core.Models;

namespace SocialApp.Data
{
    public interface ISocialAppDbContext
    {
        DbSet<T> Set<T>() where T : class; //generic thing
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

        Task<int> SaveChangesAsync(); //first 4 methods are from DbContext class 
        // async enables possibility in same time do several things

        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
    }
}
