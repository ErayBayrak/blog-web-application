﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterRepository());
        //[HttpGet]
        //public PartialViewResult SubscribeMail()
        //{
        //    return PartialView();
        //}
        //[HttpPost]
        //public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        //{
        //    newsLetter.MailStatus = true;
        //    newsLetterManager.AddNewsLetter(newsLetter);
        //    return PartialView();
        //}

        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            newsLetterManager.AddNewsLetter(newsLetter);
            return RedirectToAction("Index", "Blog");
        }
    }
}
