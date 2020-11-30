﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class UserRegistrationController : ApiController
    {
        FinanceEntities db = new FinanceEntities();
        #region ConsumerRegistration
        /// <summary>
        /// checks whether the username already exists or not;
        /// checks the user age above 10 or not;
        /// checking for unique email and phone number;
        /// encrypting the password;
        /// adding the user in the database;
        /// </summary>
        /// <param name="consumer"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Adduser(ConsumerTable consumer)
        {
            var username = (from c in db.ConsumerTables
                            where c.UserName == consumer.UserName
                            select c.UserName).ToList();
            if (username.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "This User Name is taken, Please Choose different username");
            }
            else 
            {
                var email= (from c in db.ConsumerTables
                            where c.Email==consumer.Email
                            select c.Email).ToList();
                if (email.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Userdata with given email already exists. Please choose different email or Login with current email");
                }
                else
                {
                    var phone= (from c in db.ConsumerTables
                                where c.PhoneNo==consumer.PhoneNo
                                select c.PhoneNo).ToList();
                    if (phone.Count > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Userdata with given Phone Number already exists. Please Login");
                    }
                    else
                    {
                        DateTime currentdate = System.DateTime.Now;
                        TimeSpan time = currentdate.Subtract(consumer.DateofBirth);
                        if (time.Days < 3650)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, "You are Not eligible. The user should be 10 years old or above");
                        }
                        byte[] encData_byte = new byte[consumer.Password.Length];
                        encData_byte = System.Text.Encoding.UTF8.GetBytes(consumer.Password);
                        string encodedpassword = Convert.ToBase64String(encData_byte);
                        consumer.Password = encodedpassword;

                        ConsumerTable ct = new ConsumerTable();
                        ct.UserName = consumer.UserName;
                        ct.DateofBirth = consumer.DateofBirth;
                        ct.Name = consumer.Name;
                        ct.Email = consumer.Email;
                        ct.PhoneNo = consumer.PhoneNo;
                        ct.Password = consumer.Password;
                        ct.Address = consumer.Address;
                        ct.CardType = consumer.CardType;
                        ct.SelectBank = consumer.SelectBank;
                        ct.AccountNumber = consumer.AccountNumber;
                        ct.IFSC_Code = consumer.IFSC_Code;
                        try
                        {
                            db.ConsumerTables.Add(ct);
                            db.SaveChanges();
                            db.adduserinadmin(consumer.UserName);
                            db.SaveChanges();                   
                            return Request.CreateResponse(HttpStatusCode.OK, "Registered Successfully!!!");
                        }
                        catch (Exception)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, "The mailid or the Name given is too large");
                        }
                    }
                }
            }
        }
        #endregion
        [HttpGet]
        public HttpResponseMessage getbanks()
        {
            var banks = (from b in db.Banks
                         select b.BankName).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, banks);
        }
    }
}
