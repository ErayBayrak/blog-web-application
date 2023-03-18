using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var userid = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(userid);
            return View(values);
        }
    }
}
