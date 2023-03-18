using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.WriterModelID == writerid);
            var jsonWriter = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterModel w)
        {
            writers.Add(w);
            var jsonwriter = JsonConvert.SerializeObject(w);
            return Json(jsonwriter);
        }
        public IActionResult DeleteWriter(int id)
        {
            var deletedValue = writers.FirstOrDefault(x => x.WriterModelID == id);
            writers.Remove(deletedValue);
            return Json(deletedValue);
        }
        public IActionResult UpdateWriter(WriterModel w)
        {
            var writerid = writers.FirstOrDefault(x => x.WriterModelID == w.WriterModelID);
            writerid.WriterModelName = w.WriterModelName;
            var jsonwriterid = JsonConvert.SerializeObject(w);
            return Json(jsonwriterid);
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                WriterModelID=1,
                WriterModelName="Eray"
            },
            new WriterModel
            {
                WriterModelID=2,
                WriterModelName="Mehmet"
            },
            new WriterModel
            {
                WriterModelID=3,
                WriterModelName="Ahmet"
            }
        };
    }
}
