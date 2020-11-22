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
        FinanceEntities1 db = new FinanceEntities1();
        
        
        public HttpResponseMessage GetUserInfo()
        {
            var UserList = (from con in db.ConsumerTables
                            join ad in db.Admins on con.UserName equals ad.UserName
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

        public HttpResponseMessage DeleteUserInfo(string username)
        {
            ConsumerTable CT = db.ConsumerTables.Find(username);
            if (CT == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
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
                    return Request.CreateResponse(HttpStatusCode.OK, "You cannot delete Active user");
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
                userdata.UserName = consumer.UserName;
                userdata.Name = consumer.UserName;
                userdata.PhoneNo = consumer.PhoneNo;
                userdata.Email = consumer.Email;
                userdata.Address = consumer.Address;
                userdata.Password = consumer.Password;
                userdata.CardType = consumer.CardType;
                userdata.SelectBank = consumer.SelectBank;
                userdata.IFSC_Code = consumer.IFSC_Code;
                userdata.AccountNumber = consumer.AccountNumber;
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
