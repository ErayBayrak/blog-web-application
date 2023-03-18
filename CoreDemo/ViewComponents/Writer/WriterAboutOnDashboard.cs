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
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = context.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            var values = writerManager.GetWriterById(userID);
            return View(values);
        }
    }
}
