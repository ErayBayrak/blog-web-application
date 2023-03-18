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
    [Authorize(Roles ="Admin")]
    public class AdminRoleController : Controller
    {

        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole
                {
                    Name = model.roleName
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var role = _roleManager.Roles.Where(x => x.Id == model.RoleId).FirstOrDefault();
            if (role != null)
            {
                role.Name = model.RoleName;
                if (ModelState.IsValid)
                {
                    var result = await _roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
           var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult GetListUser()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user =  _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["userId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<AssignRoleViewModel> model = new List<AssignRoleViewModel>();

            foreach (var item in roles)
            {
                AssignRoleViewModel m = new AssignRoleViewModel();
                m.RoleId = item.Id;
                m.RoleName = item.Name;
                m.RoleExists = userRoles.Contains(item.Name);
                model.Add(m);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> model)
        {
            var userid = (int)TempData["userId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.RoleExists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("GetListUser");
        }
    }
}
