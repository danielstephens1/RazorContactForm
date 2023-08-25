using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata;

namespace Website.Pages
{
    public class ContactModel : PageModel
    {

        public string IsSent { get; set; }
        

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var name = Request.Form["name"];
            var email = Request.Form["emailaddress"];
            var phone = Request.Form["phonenumber"];
            var subject = Request.Form["subject"];
            var message = Request.Form["message"];


            try
            {
                SendMail(name, email, phone, subject, message);
                IsSent = "sent";

            }

            catch (Exception)
            {
                IsSent = "failed";
                throw;
            }

        }

        public bool SendMail(string name, string email, string phone, string subject, string message1)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("no-reply@website.com", "Title");
            message.To.Add("email@gmail.com");
            message.Subject = name + ": " + subject;
            message.IsBodyHtml = true;
            message.Body = "<p>Name: " + name + "</p>" + "<p>Phone Number: " + phone + "</p>" + "<p>Email: " + email + "</p>" + "<br/><p>Message: " + message1 + "</p>";

            smtp.Port = port#;
            smtp.Host = "host.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("no-reply@website.com", "cred");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
            return true;

        }

    }
}
