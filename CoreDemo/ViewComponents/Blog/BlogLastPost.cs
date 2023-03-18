using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogLastPost:ViewComponent
    {
        //Context context = new Context();
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            //var value = context.Blogs.OrderByDescending(x => x.BlogID).Take(1).FirstOrDefault();
            var value = blogManager.GetLastBlog();
            return View(value);
        }
    }
}
