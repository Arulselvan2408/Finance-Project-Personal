using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class ActivateUserController : ApiController
    {
        FinanceEntities db = new FinanceEntities();
        //Activating the user
        [HttpGet]
        public HttpResponseMessage useractivate(string username)
        {
            try
            {
                var ad = (from a in db.Admins
                          where a.UserName == username
                          select a).FirstOrDefault();
                
                if(ad.ActivationStatus == true)
                {
                    throw new Exception ("UserActivated Already");
                }
                else
                {
                    ad.ActivationStatus = true;
                    CardTable ct = new CardTable();
                    ct.CardType = (from consumer in db.ConsumerTables
                                   where consumer.UserName == username
                                   select consumer.CardType).FirstOrDefault();
                    ct.Name = username;
                    ct.RemainingCredit = (from cardtype in db.CardTypeTables
                                          where cardtype.CardType == ct.CardType
                                          select cardtype.TotalCredit).FirstOrDefault();
                    ct.TotalCredit = Convert.ToInt32((from cardtype in db.CardTypeTables
                                                      where cardtype.CardType == ct.CardType
                                                      select cardtype.TotalCredit).FirstOrDefault());
                    ct.ValidTill = db.validtill().FirstOrDefault().ToString();
                    db.CardTables.Add(ct);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "UserActivated");

                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Activation Failed");
            }
        }
    }
}