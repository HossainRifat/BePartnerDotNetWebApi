
using BLL.Services;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;

namespace AppLayer_BePartner.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InAuthController : ApiController
    {
        [Route("api/investor/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel obj)
        {
            var data = AuthServices.Authenticate(obj.Username, obj.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound,"Incorrect Username or Password");
        }

        [Route("api/investor/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var Tkey = HttpContext.Current.Request.Headers["Authorization"];
            var data = AuthServices.Logout(Tkey);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/alluser")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AuthServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
