using AutoMapper;
using Social_app.Models;
using SocialApp.Core.Models;
using SocialApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Social_app.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PostsController : BasicApiController
    {
        public PostsController(IUserService userService, IPostsService postsService, IMapper mapper)
            : base(userService, postsService, mapper)
        {
        }

        [HttpGet, Route("api/posts/")]
        public IHttpActionResult Get(int userId)
        {
            try
            {
                var task = _postsService.GetPosts(userId);
                return Ok(_mapper.Map<List<PostResponse>>(task));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("api/posts/post")]
        public async Task<IHttpActionResult> CreatePost(Post post)
        {
            try
            {
                var task = await _postsService.CreatePost(post);
                if (task.Succeeded == false)
                {
                    return BadRequest(task.Error);
                }

                post.Id = task.Entity.Id;
                return Created("", _mapper.Map<PostResponse>(post));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut, Route("api/posts/put")]
        public IHttpActionResult UpdatePost(Post post)
        {
            if (!string.IsNullOrEmpty(post.Text) || !string.IsNullOrEmpty(post.Picture))
            {
                try
                {
                    var task = _postsService.UpdatePost(post);
                    if (task.Succeeded == false)
                    {
                        return BadRequest(task.Error);
                    }

                    return Created("", _mapper.Map<PostResponse>(post));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest("Update failed! Post should contain text or picture.");
        }

    }
}
