using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SocialApp.Core.Services;

namespace Social_app.Controllers
{
    public class BasicApiController : ApiController
    {
        protected readonly IUserService _userService;
        protected readonly IPostsService _postsService;
        protected readonly IMapper _mapper;

        public BasicApiController(IUserService userService, IPostsService postsService, IMapper mapper)
        {
            _userService = userService;
            _postsService = postsService;
            _mapper = mapper;
        }
    }
}
