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

        [HttpGet, Route("api/get/posts/")]
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

        // GET: api/Posts/5


        // POST: api/Posts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Posts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Posts/5
        public void Delete(int id)
        {
        }
    }
}
