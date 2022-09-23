
using AppLayer_BePartner.Auth;
using BLL.Services;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AppLayer_BePartner.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class IdeaController : ApiController
    {
        [InValid]
        [Route("api/idea/get/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = IdeaServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [InValid]
        [Route("api/idea/get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = IdeaServices.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/idea/create")]
        [HttpPost]
        public HttpResponseMessage Create(IdeaModel s)
        {
            if (IdeaServices.Create(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
        [InValid]
        [Route("api/idea/update")]
        [HttpPost]
        public HttpResponseMessage Update(IdeaModel s)
        {
            if (IdeaServices.Update(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data updated");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
        [InValid]
        [Route("api/idea/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (IdeaServices.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
        [InValid]
        [Route("api/idea/email/{id}")]
        [HttpGet]
        public HttpResponseMessage GetByEnEmail(string id)
        {
            id = id + ".com";
            var data = IdeaServices.GetByEnEmail(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [InValid]
        //[Route("api/idea/myinvestment/{id}")]
        [Route("api/idea/myinvestment")]
        [HttpGet]
        public HttpResponseMessage MyInvestment()
        {
            var auth = HttpContext.Current.Request.Headers["Authorization"];
            var data = IdeaServices.MyInvestment(UserNameServices.Get(auth));
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/idea/get/confirmed")]
        [HttpGet]
        public HttpResponseMessage GetIdeaConfirmed()
        {
            var data = IdeaServices.GetByConfirmed();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [InValid]
        [Route("api/idea/company/{id}")]
        [HttpGet]
        public HttpResponseMessage GetByName(string id)
        {
            var data = IdeaServices.GetByName(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [InValid]
        [Route("api/idea/confirm")]
        [HttpPost]
        public HttpResponseMessage Confirm(IdeaModel s)
        {
            var auth = HttpContext.Current.Request.Headers["Authorization"];
            s.In_Asp_Email = UserNameServices.Get(auth);
            s.Status = "Confirmed";
            if (IdeaServices.Update(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data updated");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [InValid]
        [Route("api/idea/search/{id}")]
        [HttpGet]
        public HttpResponseMessage searchIdea(string id)
        {
            var data = IdeaServices.SearchIdea(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [InValid]
        [Route("api/idea/sort/{id}")]
        [HttpGet]
        public HttpResponseMessage sortIdea(string id)
        {
            var data = IdeaServices.sortIda(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
