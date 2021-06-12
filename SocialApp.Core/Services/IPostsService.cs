using SocialApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Core.Services
{
    public interface IPostsService
    {
        IEnumerable<Post> GetPosts(int userId);
        Task<ServiceResult> CreatePost(Post post);
        ServiceResult UpdatePost(Post post);
    }
}
