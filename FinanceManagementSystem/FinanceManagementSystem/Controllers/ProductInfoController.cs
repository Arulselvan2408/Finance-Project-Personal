using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FinanceManagementSystem.Models;
using System.Collections;

namespace FinanceManagementSystem.Controllers
{
    public class ProductInfoController : ApiController
    {
        FinanceEntities3 db = new FinanceEntities3();

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            //var OrderList = (from pro in db.Products
            //                 join od in db.OrderDetails on
            //                 pro.ProductID equals od.ProductID
            //                 join orders in db.Orders
            //                 on od.OrderID equals orders.OrderID
            //                 where pro.ProductID == id
            //                 select new {pro, od, orders }).ToList().FirstOrDefault();
            return Ok(product);
        }
        //making changes on the orderdeatails, products, orders, cardtable on successful order
        public HttpResponseMessage GetOrderinfo(int productid, int quantity, int EMI, string username)
        {
            Product product = (from p in db.Products
                               where p.ProductID == productid
                               select p).FirstOrDefault();
            int TotalAmount = quantity * product.CostPerUnit;
            double ProcessingFee = 0.02 * TotalAmount;
            double AmountPayable = TotalAmount + ProcessingFee;
            double EMIperMonth = AmountPayable / EMI;
            long cardnumber = (from c in db.CardTables
                              where c.Name == username
                              select c.CardNumber).FirstOrDefault();

            Product pro = new Product();
            if (quantity< 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Quantity Should Not be zero or negative");
            }
            else if (quantity > pro.AvailableQuantity)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Products are out of Stock, Please order in less Quantity");
            }
            else
            {
                CardTable ct = new CardTable();
                if (AmountPayable > ct.RemainingCredit)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "You donot Have Enough Credits to buy this Product");
                }
                else
                {
                    try
                    {
                        db.Orders.Add(new Order { OrderDate = DateTime.Now, AmountPayable = AmountPayable, EMI_Tenure_In_Months = EMI, BillAmountperMonth = EMIperMonth, CardNumber = cardnumber, Remaining_EMI_Tenures=EMI, LastPaymentDate=null });
                        db.SaveChanges();
                    }
                    catch(Exception)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Order not placed");
                    }

                    try
                    {
                        int orderid = Convert.ToInt32((from o in db.Orders
                                                       where o.CardNumber == cardnumber
                                                       select o.OrderID).ToList().LastOrDefault());
                        db.OrderDetails.Add(new OrderDetail { OrderID = orderid, ProductID = productid, Quantity = quantity, TotalAmount = TotalAmount, ProcessingFee = ProcessingFee });
                        CardTable cardtable = (from c in db.CardTables
                                               where c.CardNumber == cardnumber
                                               select c).FirstOrDefault();
                        cardtable.RemainingCredit = cardtable.RemainingCredit - AmountPayable;
                        Product Pro1 = (from p in db.Products
                                       where p.ProductID == productid
                                       select p).FirstOrDefault();
                        Pro1.AvailableQuantity = Pro1.AvailableQuantity - quantity;
                        db.SaveChanges();

                    }
                    catch (Exception e)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, e);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "Order Placed & Purchase Successfull. Your EMI amount Per Month is"+" "+EMIperMonth);
                }
            }
        }
    }   
}
