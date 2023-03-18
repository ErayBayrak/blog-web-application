using CoreDemo.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminRegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminRegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminSignUpViewModel p)
        {
            AppUser user = new AppUser()
            {
                
                UserName = p.username,
                Email = p.mail,
                NameSurname = p.nameSurname
                
            };
            var result = await _userManager.CreateAsync(user, p.password);
            //var addRoleToUser = await _userManager.AddToRoleAsync(user, p.role);
            if (result.Succeeded /*&& addRoleToUser.Succeeded*/)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(p);
        }
    }
}
