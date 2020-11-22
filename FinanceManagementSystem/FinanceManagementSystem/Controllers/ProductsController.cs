using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class ProductsController : ApiController
    {
        FinanceEntities1 db = new FinanceEntities1();
        public HttpResponseMessage GetProducts()
        {
            var products = (from p in db.Products
                            select p);
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }
        
    }
}
