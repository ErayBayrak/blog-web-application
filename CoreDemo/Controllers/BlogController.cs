using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        //[AllowAnonymous]
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        //[AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.blog_id_value = id;
            var values = blogManager.GetBlogById(id);
            return View(values);
        }
        public IActionResult GetBlogByWriter()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = context.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            ViewBag.v = userID;
            var values = blogManager.GetListWithCategoryByWriterBM(userID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categoryvalues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }
                                                   ).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = context.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.BlogStatus = true;
                blog.WriterID = userID;
                List<SelectListItem> categoryvalues = (from x in categoryManager.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID.ToString()
                                                       }
                                                   ).ToList();
                ViewBag.cv = categoryvalues;
                blogManager.TAdd(blog);
                return RedirectToAction("GetBlogByWriter", "Blog");
            }
            else
            {
                foreach (var x in results.Errors)
                {

                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeleteBlog(int id)
        {
            var deletedValue = blogManager.GetById(id);
            blogManager.TDelete(deletedValue);
            return RedirectToAction("GetBlogByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var values = blogManager.GetById(id);
            List<SelectListItem> categoryvalues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }
                                                   ).ToList();
            ViewBag.cv = categoryvalues;
            
            return View(values);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var usermail = context.AppUsers.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = context.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterID).FirstOrDefault();
            blog.WriterID = userID;
            blog.BlogStatus = true;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blogManager.TUpdate(blog);
            return RedirectToAction("GetBlogByWriter");
        }

    }
}
