using System.Data.Entity;
using SocialApp.Core.Models;


namespace SocialApp.Data
{
    public class SocialAppDbContext: DbContext, ISocialAppDbContext
    {
        public SocialAppDbContext() : base("SocialAppData")
        {
            Database.SetInitializer<SocialAppDbContext>(null);

            //Database.SetInitializer<SocialAppDbContext>(
            //    new MigrateDatabaseToLatestVersion<SocialAppDbContext, Configuration>()); // if new migration will happen ... everything will happen automatically, user even do not notice it; golden line
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
