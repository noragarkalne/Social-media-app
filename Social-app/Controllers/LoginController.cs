using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Social_app.Attributes;
using SocialApp.Core.Models;
using SocialApp.Core.Services;


namespace Social_app.Controllers
{
    [BasicAuthentification]
    [Route("login")]

    public class LoginController : BasicApiController
    {
        public LoginController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
        }

        [HttpGet]
        public async Task<IHttpActionResult> Login(string email, string password)
        {
            var user = await _userService.GetUser(email, password);
            if (user.Succeeded)
            {
                return Ok("viss notiek");
            }

            if (user.Succeeded == false)
            {
                return BadRequest("viss slikti");
            }

            return NotFound();
        }


        
    }
}
