using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class emirepaymentController : ApiController
    {
        FinanceEntities3 db = new FinanceEntities3();
        #region EMI REPAYMENT
        [HttpGet]
        public HttpResponseMessage EmiRepayment(int orderid)
        {
            var orderinfo = (from o in db.Orders
                             where o.OrderID == orderid
                             select o).FirstOrDefault();
            if(orderinfo.LastPaymentDate != null && orderinfo.Remaining_EMI_Tenures != 0)
            {
                DateTime currentdate = System.DateTime.Now;
                TimeSpan time = currentdate.Subtract((DateTime)orderinfo.LastPaymentDate);
                DateTime nextdue = (DateTime)orderinfo.LastPaymentDate;
                DateTime nextduedate = nextdue.AddDays(30);
                if (time.Days < 30)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "The Payment for this Month is made already. Next Due Date is" + " " + nextduedate);
                }
                else
                {
                    try
                    {
                        orderinfo.Remaining_EMI_Tenures = orderinfo.Remaining_EMI_Tenures - 1;
                        orderinfo.LastPaymentDate = System.DateTime.Now;
                        var card = (from c in db.CardTables
                                    where c.CardNumber == orderinfo.CardNumber
                                    select c).FirstOrDefault();
                        card.RemainingCredit = card.RemainingCredit + orderinfo.BillAmountperMonth;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Your EMI amount for the Tenure" + " " + (orderinfo.EMI_Tenure_In_Months - orderinfo.Remaining_EMI_Tenures) +
                            " " + "out of" + " " + orderinfo.EMI_Tenure_In_Months + " " + "has been Paid");
                    }
                    catch (Exception e)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Payment Failed!!" + e.Message);
                    }
                }
                
            }
            else if(orderinfo.LastPaymentDate == null && orderinfo.Remaining_EMI_Tenures != 0)
            {
                try
                {
                    orderinfo.Remaining_EMI_Tenures = orderinfo.Remaining_EMI_Tenures - 1;
                    orderinfo.LastPaymentDate = System.DateTime.Now;
                    var card = (from c in db.CardTables
                                where c.CardNumber == orderinfo.CardNumber
                                select c).FirstOrDefault();
                    card.RemainingCredit = card.RemainingCredit + orderinfo.BillAmountperMonth;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Your EMI amount for the Tenure" + " " + (orderinfo.EMI_Tenure_In_Months - orderinfo.Remaining_EMI_Tenures) +
                        " " + "out of" + " " + orderinfo.EMI_Tenure_In_Months + " " + "has been Paid");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Payment Failed!!" + e.Message);
                }

            }
            return Request.CreateResponse(HttpStatusCode.OK, "The EMI amount for all the Tenure has been paid. Thank You for using our service");
        }
    
        #endregion
    }
}
