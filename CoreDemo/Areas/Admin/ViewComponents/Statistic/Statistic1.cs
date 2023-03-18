using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.totalBlogCount = c.Blogs.Count();
            ViewBag.totalContactCount = c.Message2s.Count();
            ViewBag.totalCommentCount = c.Comments.Count();

            string api = "3026a8342f023a2fb4c54adcfd75b029";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            string TempToIstanbul = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            var cevrilmis = TempToIstanbul.Substring(0,3);
            //var cevrilmis = float.Parse(TempToIstanbul, CultureInfo.InvariantCulture.NumberFormat);

            ViewBag.celciusTemperature = cevrilmis;
            return View();
        }
    }
}
