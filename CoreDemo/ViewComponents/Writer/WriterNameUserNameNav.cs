using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNameUserNameNav:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.username = userName;
            var usermail = c.AppUsers.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var nameSurname = c.AppUsers.Where(x => x.Email == usermail).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.namesurname = nameSurname;
            return View();
        }
    }
}
