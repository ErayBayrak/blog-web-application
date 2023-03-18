using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();
        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = context.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(userID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = context.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            var values = message2Manager.GetSendboxListByWriter(userID);
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 message)
        {
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = context.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            message.ReceiverID = 1;
            message.SenderID = userID;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = true;
            message2Manager.TAdd(message);
            return RedirectToAction("SendBox");
        }
    }
}
