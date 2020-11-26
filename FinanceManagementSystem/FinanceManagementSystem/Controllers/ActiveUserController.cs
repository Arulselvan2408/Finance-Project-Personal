using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class ActiveUserController : ApiController
    {
        FinanceEntities3 db = new FinanceEntities3();
        public HttpResponseMessage GetActivatedUserInfo()
        {
            var UserList = (from con in db.ConsumerTables
                            join ad in db.Admins on con.UserName equals ad.UserName
                            where ad.ActivationStatus == true
                            select new
                            {
                                con.UserName,
                                con.Name,
                                con.DateofBirth,
                                con.PhoneNo,
                                con.Email,
                                con.Address,
                                con.CardType,
                                con.SelectBank,
                                con.IFSC_Code,
                                con.AccountNumber,
                                ad.ActivationStatus
                            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, UserList);
        }
    }
}
