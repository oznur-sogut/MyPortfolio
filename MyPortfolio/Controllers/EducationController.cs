using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class EducationController : Controller
    {
        MyPortfolioDbEntities db= new MyPortfolioDbEntities();
        [Authorize]
        public ActionResult EducationIndex()
        {
            var value = db.MyCertificate.ToList();
            return View(value);
        }
    }
}