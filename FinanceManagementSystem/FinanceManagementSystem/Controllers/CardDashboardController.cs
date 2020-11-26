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
        FinanceEntities3 db = new FinanceEntities3();

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
            List<CreditDetails> creditlist = new List<CreditDetails>();
            var cl = (from c in db.CardTables
                      where c.Name == username
                      select new { c.TotalCredit, Creditused = (c.TotalCredit - c.RemainingCredit), c.RemainingCredit }
                     ).ToList();
            return cl;


        }
        #endregion
        #region products_purchased

        [HttpGet]
        [Route("api/CardDashboard/GetProducts")]
        public IEnumerable GetProductspurchased(string username)
        {
            List<ProductPurchase> productslist = new List<ProductPurchase>();
            var pl = (from p in db.Products
                      join od in db.OrderDetails on
                      p.ProductID equals od.ProductID
                      join o in db.Orders on od.OrderID
                      equals o.OrderID
                      join c in db.CardTables on o.CardNumber equals c.CardNumber
                      where c.Name == username
                      select new { od.OrderID, p.ProductName, p.CostPerUnit, o.AmountPayable, Balance = (c.TotalCredit - o.AmountPayable) }

                    ).ToList();

            return pl;
        }
        #endregion

        #region recent_transactions
        [HttpGet]
        [Route("api/CardDashboard/GetTransactions")]
        public IEnumerable GetRecenttransactions(string username)
        {
            List<RecentTransaction> transactionlist = new List<RecentTransaction>();
            var tl = (from p in db.Products
                      join od in db.OrderDetails on
                      p.ProductID equals od.ProductID
                      join o in db.Orders on od.OrderID
                      equals o.OrderID
                      join c in db.CardTables on o.CardNumber equals c.CardNumber
                      where c.Name == username
                      select new { od.OrderID, p.ProductName, o.OrderDate, o.AmountPayable, o.EMI_Tenure_In_Months, o.Remaining_EMI_Tenures, o.LastPaymentDate, o.BillAmountperMonth }

                    ).ToList();

            return tl;
        }
        #endregion

    }
}
