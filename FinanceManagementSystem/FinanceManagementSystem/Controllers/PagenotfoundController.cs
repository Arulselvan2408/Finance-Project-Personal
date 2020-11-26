using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinanceManagementSystem.Controllers
{
    public class PagenotfoundController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ErrorPage()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
