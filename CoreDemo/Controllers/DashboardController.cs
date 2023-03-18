using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var userid = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.totalBlogCount = context.Blogs.Count().ToString();
            ViewBag.totalBlogCountOfWriter = context.Blogs.Where(x => x.WriterID == userid).Count().ToString();
            ViewBag.totalCategoryCount = context.Categories.Count().ToString();
            return View();
        }
    }
}
