
using AppLayer_BePartner.Auth;
using BLL.Services;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AppLayer_BePartner.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    
    public class InvestorController : ApiController
    {
        [Route("api/investor/get/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = InvestorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [InValid]
        [Route("api/investor/at")]
        [HttpGet]
        public HttpResponseMessage Gett()
        {
            string authHeader = HttpContext.Current.Request.Headers["Authorization"];
            //var data = InvestorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, authHeader);
        }
        [InValid]
        [Route("api/investor/profile")]
        [HttpGet]
        public HttpResponseMessage GetProfile()
        {
            //id = id + ".com";
            var auth = HttpContext.Current.Request.Headers["Authorization"];
            var data = InvestorService.Get(UserNameServices.Get(auth));
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/investor/create")]
        [HttpPost]
        public HttpResponseMessage Create(InvestorModel s)
        {
            if (InvestorService.Create(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data inserted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound,"Something went wrong");
        }
        [InValid]
        [Route("api/investor/update")]
        [HttpPost]
        public HttpResponseMessage Update(InvestorModel s)
        {
            if (InvestorService.Update(s))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data updated");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/investor/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(string id)
        {
            id = id + ".com";
            if (InvestorService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Data deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }
        [InValid]
        [Route("api/investor/download")]
        [HttpGet]
        public HttpResponseMessage Download()
        {
            var auth = HttpContext.Current.Request.Headers["Authorization"];

            //if (InvestorService.DownloadMyInvestment("rh140025@gmail.com"))
            if (InvestorService.DownloadMyInvestment(UserNameServices.Get(auth)))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "File is saved in download folder as MyInvestment.xlsx");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

        [Route("api/investor/verification/create")]
        [HttpPost]
        public HttpResponseMessage createVerification(VarificationModel V)
        {
            if (InvestorService.createVarification(V))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Verification Code Sent");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Already Verified");
        }

        [Route("api/investor/verification/check")]
        [HttpPost]
        public HttpResponseMessage checkVerification(VarificationModel V)
        {
            if (InvestorService.checkVarification(V))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "verified");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
        }

    }
}
