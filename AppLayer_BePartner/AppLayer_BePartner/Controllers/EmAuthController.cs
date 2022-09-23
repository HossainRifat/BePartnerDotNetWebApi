using BLL.Services;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AppLayer_BePartner.Controllers
{
    public class EmAuthController : ApiController
    {
        [Route("api/employee/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel obj)
        {
            var data = AuthServices.Authenticate(obj.Username, obj.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Incorrect Username or Password");
        }

        [Route("api/employee/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var Tkey = HttpContext.Current.Request.Headers["Authorization"];
            var data = AuthServices.Logout(Tkey);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
