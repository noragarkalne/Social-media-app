using SocialApp.Core.Models;
using SocialApp.Core.Services;
using SocialApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Service
{
    public class PostsService : EntityService<Post>, IPostsService
    {
        public PostsService(ISocialAppDbContext context) : base(context)
        {

        }

        public PostsService()
        {

        }

        public IEnumerable<Post> GetPosts(int userId)
        {
            return GetAllByUserId(userId);
        }

        public async Task<ServiceResult> CreatePost(Post post)
        {
            return await Create(post);
        }


    }
}
