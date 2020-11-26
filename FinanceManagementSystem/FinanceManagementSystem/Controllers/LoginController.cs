﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class LoginController : ApiController
    {
        FinanceEntities1 db = new FinanceEntities1();
        [HttpPost]
        public HttpResponseMessage verifylogin(ConsumerTable logininfo)
        {
            var user = (from consumer in db.ConsumerTables
                        where consumer.UserName == logininfo.UserName && consumer.Password == logininfo.Password
                        select consumer.Name).FirstOrDefault();
            if(user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Invalid");
            }

        }
    }
}