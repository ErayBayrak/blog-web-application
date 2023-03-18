using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = categoryManager.GetList().Where(x=>x.CategoryStatus==true).ToPagedList(page,3);
            return View(values);
        }
    
    [HttpGet]
    public IActionResult AddCategory()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        CategoryValidator validationRules = new CategoryValidator();
        ValidationResult result = validationRules.Validate(category);
        if (result.IsValid)
        {
                category.CategoryStatus = true;
                categoryManager.TAdd(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach(var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
        return View();
    }
        public IActionResult DeleteCategory(int id)
        {
            var values = categoryManager.GetById(id);
            values.CategoryStatus = false;
            categoryManager.TUpdate(values);
            return RedirectToAction("Index","Category");
        }
    }
}
