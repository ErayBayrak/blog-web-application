using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        AppUserManager appUserManager = new AppUserManager(new EfAppUserRepository());
        
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            
            var usermail = User.Identity.Name;
            ViewBag.useremail = usermail;
            Context context = new Context();
            var username = context.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterName).FirstOrDefault();
            ViewBag.un = username;
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
           
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
       

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();

            model.email = values.Email;
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.imageurl = values.ImageUrl;
     
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.email;
            values.NameSurname = model.namesurname;
            values.UserName = model.username;
            values.ImageUrl = model.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer writer1 = new Writer();
            if (writer.WriterImage != null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                writer1.WriterImage = newImageName;
            }
            writer1.WriterMail = writer.WriterMail;
            writer1.WriterName = writer.WriterName;
            writer1.WriterPassword = writer.WriterPassword;
            writer1.WriterStatus = true;
            writer1.WriterAbout = writer.WriterAbout;
            writerManager.TAdd(writer1);
            return RedirectToAction("Index", "Dashboard");
        }
        
    }
}
