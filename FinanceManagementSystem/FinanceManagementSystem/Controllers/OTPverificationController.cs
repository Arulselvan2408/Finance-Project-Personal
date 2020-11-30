using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class OTPverificationController : ApiController
    {
        FinanceEntities db = new FinanceEntities();
        public HttpResponseMessage verifyOTP(string email, int otp)
        {
            var user = (from con in db.ConsumerTables
                        where con.Email == email
                        select con.UserName).FirstOrDefault();
            if(user==null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Invalid Email");
            }
            else
            {
                var otpvalid = (from valid in db.OTP_Validation
                                where valid.UserName == user
                                select valid.OTP_Sent).FirstOrDefault();
                if (otpvalid == otp)
                {
                    var otpdetails = (from valid in db.OTP_Validation
                                      where valid.UserName == user
                                      select valid).FirstOrDefault();
                    db.OTP_Validation.Remove(otpdetails);
                    return Request.CreateResponse(HttpStatusCode.OK, "OTP validation Successful");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "You have entered wrong OTP. Please enter the correct OTP");
                }
            }
        }
    }
}
