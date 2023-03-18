using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var result = (from blog in c.Blogs
                          join categori in c.Categories on blog.CategoryID equals categori.CategoryID
                          group categori by categori.CategoryName into g
                          orderby g.Count() descending
                          select g.Key).FirstOrDefault();
            ViewBag.v1 = result;

            var result2 = (from blog in c.Blogs
                          join writer in c.Writers on blog.WriterID equals writer.WriterID
                          group writer by writer.WriterName into g
                          orderby g.Count() descending
                          select g.Key).FirstOrDefault();
            ViewBag.v2 = result2;

            ViewBag.v3 = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).FirstOrDefault();
            return View();
        }
    }
}
