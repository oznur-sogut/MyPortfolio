using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class StatisticController : Controller
    {
       MyPortfolioDbEntities db= new MyPortfolioDbEntities();
        [Authorize]
        public ActionResult StatisticIndex()
        {
            ViewBag.totalProjectCount = db.Project.Count();
            ViewBag.totalTestimonial=db.Testimonial.Count();
            ViewBag.sumWorkDay = db.Project.Sum(x => x.CompleteDay);
            ViewBag.avgWorkDay= db.Project.Average(x => x.CompleteDay);
            ViewBag.avgPrice = db.Project.Average(x=>x.Price);
            //Frameworkte Alt sorgu oluşturma ---> Select*From Project Where Price=(Select Max(Price) from Project)
            var value = db.Project.Max(x => x.Price);
            ViewBag.maxPriceProject = db.Project.Where(x => x.Price == value).Select(y=>y.ProjectTitle).FirstOrDefault();
            return View();
        }
    }
}