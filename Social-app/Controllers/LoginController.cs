using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using AutoMapper;
using Social_app.Attributes;
using SocialApp.Core.Models;
using SocialApp.Core.Services;



namespace Social_app.Controllers
{
    //[BasicAuthentification]
    [EnableCors("*", "*", "*")]

    public class LoginController : BasicApiController
    {
        public LoginController(IUserService userService, IPostsService postsService, IMapper mapper)
            : base(userService, postsService, mapper)
        {
        }

        [HttpPost, Route("api/post/login")]
        public async Task<IHttpActionResult> Login(User user)
        {

            var task = await _userService.GetUser(user.Email, user.Password);
            if (task.Succeeded)
            {
                return Ok(task.Entity);
            }

            if (task.Succeeded == false)
            {
                return BadRequest(task.Error);
            }

            return NotFound();
        }


        
    }
}
