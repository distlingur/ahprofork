using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHProfork.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AHProfork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmailForm model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(model.FromEmail);

                mail.To.Add("anna@ahprofork.is");
                mail.Subject = model.subject;
                mail.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);

                
                mail.IsBodyHtml = true;
                NetworkCredential credential = new NetworkCredential("anna@ahprofork.is", "annahel1512");
                using (var smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Send(mail);
                    return View("Sent");

                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
   
}