using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{

    public class ChartController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult CategoryChart()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(new CategoryModel
            {
                categoryname = "Teknoloji",
                categorycount = 3
            });
            list.Add(new CategoryModel
            {
                categoryname = "Yazılım",
                categorycount = 5
            });
            list.Add(new CategoryModel
            {
                categoryname = "Kimya",
                categorycount = 10
            });
            return Json(new { jsonlist = list });
        }
    }
}
