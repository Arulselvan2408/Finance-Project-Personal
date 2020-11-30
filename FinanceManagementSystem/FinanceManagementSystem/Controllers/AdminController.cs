using FinanceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FinanceManagementSystem.Image
{
    public class AdminController : ApiController
    {
        FinanceEntities db = new FinanceEntities();
        
        
        public HttpResponseMessage GetUserInfo()
        {
            try
            {
                var UserList = (from con in db.ConsumerTables
                                join ad in db.Admins on con.UserName equals ad.UserName
                                where ad.ActivationStatus == false
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
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Userdata Not Found");
            }
        }

        public HttpResponseMessage DeleteUserInfo(string username)
        {
            ConsumerTable CT = db.ConsumerTables.Find(username);
            if (CT == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Userdata not Found");
                //return NotFound();
            }
            else
            {
                var ad = (from admin in db.Admins
                          where admin.UserName == CT.UserName
                          select admin).ToList().FirstOrDefault();
                try
                {
                    db.Admins.Remove(ad);
                    db.Admins.Remove(ad);
                    db.ConsumerTables.Remove(CT);
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, "UserInfo Deleted");
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "UserInfo not Deleted");
                }
            }
           
        }
        [HttpGet]
        
        public HttpResponseMessage EditUserinfo(string username)
        {
            try
            {
                var UserList = (from con in db.ConsumerTables
                                join ad in db.Admins on con.UserName equals ad.UserName
                                where con.UserName == username
                                select new
                                {
                                    con.UserName,
                                    con.Name,
                                    con.DateofBirth,
                                    con.PhoneNo,
                                    con.Email,
                                    con.Address,
                                    con.Password,
                                    con.CardType,
                                    con.SelectBank,
                                    con.IFSC_Code,
                                    con.AccountNumber,
                                    ad.ActivationStatus
                                }).ToList().FirstOrDefault();
                 return Request.CreateResponse(HttpStatusCode.OK, UserList);
                
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Userdata doesnot exists");
            }
        }
        [HttpPut]
        public HttpResponseMessage updateuserinfo(string username, ConsumerTable consumer)
        {
            try
            {
                var userdata = (from con in db.ConsumerTables
                                where con.UserName == username
                                select con).FirstOrDefault();               
                userdata.Name = consumer.Name;
                userdata.PhoneNo = consumer.PhoneNo;
                userdata.Email = consumer.Email;
                userdata.Address = consumer.Address;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Record Updated");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Phone Number & Email should be Unique for Particular user");
            }
            
        }
    }
}
