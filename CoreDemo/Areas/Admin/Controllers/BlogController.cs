using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach(var x in GetBlogList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = x.BlogModelID;
                    workSheet.Cell(BlogRowCount, 2).Value = x.BlogModelName;
                    BlogRowCount++;
                }
                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Calisma1.xlsx");
                }
            }
            
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModelList = new List<BlogModel>
            {
                new BlogModel{BlogModelID=1,BlogModelName="C# Programlamaya Giriş"},
                new BlogModel{BlogModelID=2,BlogModelName="Tesla Firmasının Araçları"},
                new BlogModel{BlogModelID=3,BlogModelName="2022 Olimpiyatları"}
            };
            return blogModelList;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var x in DynamicGetBlogList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = x.BlogModelID;
                    workSheet.Cell(BlogRowCount, 2).Value = x.BlogModelName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> DynamicGetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>();
            using(var context = new Context())
            {
                bm = context.Blogs.Select(x => new BlogModel
                {
                    BlogModelID=x.BlogID,
                    BlogModelName=x.BlogTitle
                }).ToList();
            }
            return bm;
        }
        public IActionResult DynamicBlogListExcel()
        {
            return View();
        }
    }
}
