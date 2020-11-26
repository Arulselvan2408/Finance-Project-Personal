using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class HomePageController : ApiController
    {
        FinanceEntities3 db = new FinanceEntities3();
        public HttpResponseMessage getProduct()
        {
            var ProductList = (from prod in db.Products
                               select prod).ToList().Take(3);
            return Request.CreateResponse(HttpStatusCode.OK, ProductList);
        }

    }
}
