using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Controllers
{
    public class GetOTPController : ApiController
    {
        FinanceEntities db = new FinanceEntities();
        public async Task<int> GetOtp(string email)
        {
            Random generator = new Random();
            int r = generator.Next(100000, 1000000);
            SmtpClient smtp = new SmtpClient();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("team7finance@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Forgot Password";
            mailMessage.Body = "Dear User,Your OTP is" + r;
            await Task.Run(() => smtp.SendAsync(mailMessage, null));
            return r;
        }
        [HttpGet]
        public async Task<string> sendOTP(string email, int OTP)
        {
            var user = (from con in db.ConsumerTables
                        where con.Email == email
                        select con.UserName).FirstOrDefault();
            if (user != null)
            {
                db.OTP_Validation.Add(new OTP_Validation { UserName = user, OTP_Sent = OTP });
                db.SaveChanges();
                SmtpClient smtp = new SmtpClient();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("team7finance@gmail.com");
                mailMessage.To.Add(email);
                mailMessage.Subject = "Forgot Password";
                mailMessage.Body = "Dear User,Your OTP is " + OTP;
                await Task.Run(() => smtp.SendAsync(mailMessage, null));
                return "OTP sent to the email";
            }
            else
            {
                return "Please Enter the valid Email";
            }
            
            

        }
    }
}
