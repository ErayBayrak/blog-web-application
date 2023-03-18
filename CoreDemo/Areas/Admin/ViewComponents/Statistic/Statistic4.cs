using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = c.Admins.Where(x => x.AdminID == 1).Select(y => y.UserName).FirstOrDefault();
            ViewBag.image = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.shortDescription = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
