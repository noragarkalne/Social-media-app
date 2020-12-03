using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Social_app.Models;
using SocialApp.Core.Models;
using SocialApp.Core.Services;

namespace Social_app.Controllers
{
    [EnableCors("*", "*", "*")]
    [Route("api/put/register")]
    public class RegisterController : BasicApiController
    {
        public RegisterController(IUserService userService, IMapper mapper)
            : base(userService, mapper)
        {
        }


        [HttpPut]
        public async Task<IHttpActionResult> Add(User user)
        {

            var task = await _userService.AddNewUser(user);

            if (task.Succeeded == false)
            {
                return Conflict();
            }

            user.Id = task.Entity.Id;
            return Created("", _mapper.Map<UserResponse>(user));

        }
    }
}
