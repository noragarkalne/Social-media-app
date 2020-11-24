using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Social_app.Attributes;


namespace Social_app.Controllers
{
    [BasicAuthentification]
    [Route("login")]

    public class AccountController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Login()
        {
            return Ok("viss notiek");
        }



      
    }
}
