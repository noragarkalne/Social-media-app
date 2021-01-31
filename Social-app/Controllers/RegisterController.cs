using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Social_app.Models;
using SocialApp.Core.Models;
using SocialApp.Core.Services;
using SocialApp.Service.Exceptions;

namespace Social_app.Controllers
{
    [EnableCors("*", "*", "*")]
    [Route("api/post/register")]
    public class RegisterController : BasicApiController
    {
        public RegisterController(IUserService userService, IMapper mapper)
            : base(userService, mapper)
        {
        }


        [HttpPost]
        public async Task<IHttpActionResult> Add(User user)
        {
            try
            {
                var task = await _userService.AddNewUser(user);
                if (task.Succeeded == false)
                {
                    return BadRequest(task.Error);
                }

                user.Id = task.Entity.Id;
                return Created("", _mapper.Map<UserResponse>(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
