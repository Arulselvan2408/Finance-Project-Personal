using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class LoginController : ApiController
    {
        FinanceEntities db = new FinanceEntities();
        #region LoginVerification
        /// <summary>
        /// checking whether the particular user exists or not
        /// decrypting the password which is present in database
        /// checking for username and password match
        /// checking the activation status of user
        /// redirecting based on the activation status
        /// </summary>
        /// <param name="logininfo"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage verifylogin(ConsumerTable logininfo)
        {
            try
            {
                var pas = (from consumer in db.ConsumerTables
                           where consumer.UserName == logininfo.UserName
                           select consumer.Password).FirstOrDefault();
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder decoder = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(pas);
                int charCount = decoder.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                decoder.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string pass = new String(decoded_char);
                var user = (from consumer in db.ConsumerTables
                            where consumer.UserName == logininfo.UserName && pass == logininfo.Password
                            select consumer.UserName).FirstOrDefault();
                var act = (from ad in db.Admins
                           where ad.UserName == logininfo.UserName
                           select ad.ActivationStatus).FirstOrDefault();
                if (act == false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Not Activated by Admin");
                }
                else if (user != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Invalid");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, e.Message);
            }

        }
        #endregion
    }
}
