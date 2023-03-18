using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNameNav:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var mail = c.AppUsers.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var namesurname = c.AppUsers.Where(x => x.Email == mail).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.namesurname = namesurname;
            return View();
        } 
    }
}
