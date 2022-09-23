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
    //[InValid]
    public class OfferController : ApiController
    {
        [Route("api/offer/get/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = OfferServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/offer/company/{id}")]
        [HttpGet]
        public HttpResponseMessage GetByCompany(string id)
        {
            var data = OfferServices.getByCompany(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/offer/get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = OfferServices.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/offer/create")]
        [HttpPost]
        public HttpResponseMessage Create(OfferModel s)
        {
            var auth = HttpContext.Current.Request.Headers["Authorization"];
            s.In_Email = UserNameServices.Get(auth);

            if (OfferServices.Create(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/offer/update")]
        [HttpPost]
        public HttpResponseMessage Update(OfferModel s)
        {
            if (OfferServices.Update(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data updated");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/offer/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(string id)
        {
            if (OfferServices.Delete(int.Parse(id)))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/offer/myoffer")]
        [HttpGet]
        public HttpResponseMessage MySentOffer()
        {
            var auth = HttpContext.Current.Request.Headers["Authorization"];
            var data = OfferServices.MySentOffer(UserNameServices.Get(auth));
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/offer/deletebymail/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteByInEmail(string id)
        {
            id += ".com";
            if (OfferServices.DeleteByInEmail(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/offer/company/myoffer/{id}")]
        [HttpGet]
        public HttpResponseMessage mySentOfferByCompany(string id)
        {
            var auth = HttpContext.Current.Request.Headers["Authorization"];
            var data = OfferServices.mySentOfferByCompany(id,UserNameServices.Get(auth));
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
