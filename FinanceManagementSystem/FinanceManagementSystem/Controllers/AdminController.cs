using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;


namespace FinanceManagementSystem.Controllers
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
                                con.Password,
                                con.CardType,
                                con.SelectBank,
                                con.IFSC_Code,
                                con.AccountNumber,
                                ad.ActivationStatus
                            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, UserList);
        }
        public IHttpActionResult insertInfo(ConsumerTable consumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            
                db.ConsumerTables.Add(consumer);
                Admin ad = new Admin();
                ad.AdminID = 4001;
                ad.AdminName = "Rajiv";
                ad.UserName = consumer.UserName;
                ad.ActivationStatus = false;
                db.SaveChanges();
            
           
            return StatusCode(HttpStatusCode.NoContent);

        }

        public IHttpActionResult DeleteUserInfo(string username)
        {
            ConsumerTable CT = db.ConsumerTables.Find(username);
            if(CT==null)
            {
                return NotFound();
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
                }
                catch (Exception)
                {
                    throw new Exception("You cannot delete Active User");
                }
            }
            return Ok(username);
        }
        public IHttpActionResult EditUserinfo(string username, ConsumerTable consumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(username != consumer.UserName)
            {
                return BadRequest(ModelState);
            }
            db.Entry(consumer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
