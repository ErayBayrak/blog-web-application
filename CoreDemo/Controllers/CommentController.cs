using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentStatus = true;
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.BlogID = 1;
            commentManager.TAdd(comment);
            return RedirectToAction("BlogReadAll", "Blog", new { id = comment.BlogID });
        }
        public PartialViewResult CommentListOnBlog(int id)
        {
            var values = commentManager.GetList(id);
            return PartialView(values);
        }
    }
}
