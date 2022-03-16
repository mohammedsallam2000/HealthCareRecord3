using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public static class MailSender
    {

        public static string SendMail(MailViewModel model)
        {


            try
            {

                // Insert Host Name and Port Number
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                // Encrypt for request
                smtp.EnableSsl = true;

                // Insert Credentials
                smtp.Credentials = new NetworkCredential("healthcarerecord3@gmail.com", "HCR12345");

                // Send Your Message
                smtp.Send("healthcarerecord3@gmail.com", model.Email , model.Title, model.Message);

                var Result = "Mail Sent";
                
                return Result;
            
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
