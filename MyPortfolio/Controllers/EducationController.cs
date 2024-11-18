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
            var value = db.MyEducation.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value= db.MyEducation.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation (MyEducation myEducation)
        {
            var value=db.MyEducation.Find(myEducation.EducationID);
            value.EducationTitle = myEducation.EducationTitle;
            value.EducationSubTitle = myEducation.EducationSubTitle;
            db.SaveChanges();
            return RedirectToAction("EducationIndex");
        }
    }
}