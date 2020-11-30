using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.ViewModel;

namespace FinanceManagementSystem.Controllers
{
    public class CardDashboardController : ApiController
    {
        FinanceEntities db = new FinanceEntities();

        #region carddetails
        [HttpGet]
        [Route("api/CardDashboard/CardDetails")]
        public HttpResponseMessage CardDetails(string username)
        {
            var card = (from c in db.CardTables
                        where c.Name == username
                        select new { c.CardNumber, c.Name, c.ValidTill, c.CardType }
                     ).ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, card);


        }
        #endregion

        #region creditdetails
        [HttpGet]
        [Route("api/CardDashboard/GetCreditDetails")]
        public IEnumerable GetCreditDetails(string username)
        {
            try
            {
                var cl = (from c in db.CardTables
                          where c.Name == username
                          select new { c.TotalCredit, Creditused = (c.TotalCredit - c.RemainingCredit), c.RemainingCredit }
                     ).ToList();
                return cl;
            } 
            catch(Exception e)
            {
                return e.Message;
            }

        }
        #endregion
        #region products_purchased

        [HttpGet]
        [Route("api/CardDashboard/GetProducts")]
        public HttpResponseMessage GetProductspurchased(string username)
        {
            try
            {
                var productlist = (from card in db.CardTables
                                   join o in db.Orders on card.CardNumber equals o.CardNumber
                                   join od in db.OrderDetails on o.OrderID equals od.OrderID
                                   join p in db.Products on od.ProductID equals p.ProductID
                                   orderby o.OrderDate descending
                                   where card.Name == username
                                   select new { p.ProductName, o.AmountPayable, AmountPaid = ((o.EMI_Tenure_In_Months - o.Remaining_EMI_Tenures) * o.BillAmountperMonth), Balance = o.AmountPayable - ((o.EMI_Tenure_In_Months - o.Remaining_EMI_Tenures) * o.BillAmountperMonth), od.Quantity }).ToList().Take(2);
                return Request.CreateResponse(HttpStatusCode.OK, productlist);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, e.Message);
            }
            
                             
        }
        #endregion

        #region recent_transactions
        [HttpGet]
        [Route("api/CardDashboard/GetTransactions")]
        public IEnumerable GetRecenttransactions(string username)
        {
            
            var tl = (from p in db.Products
                      join od in db.OrderDetails on
                      p.ProductID equals od.ProductID
                      join o in db.Orders on od.OrderID
                      equals o.OrderID
                      join c in db.CardTables on o.CardNumber equals c.CardNumber
                      orderby o.OrderDate descending
                      where c.Name == username
                      select new { od.OrderID, p.ProductName, o.OrderDate, o.AmountPayable, o.EMI_Tenure_In_Months, o.Remaining_EMI_Tenures, o.LastPaymentDate, o.BillAmountperMonth }

                    ).ToList();

            return tl;
        }
        #endregion

    }
}
