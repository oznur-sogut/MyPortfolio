using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        //partialView--> sayfanın bütününü parçalar az bir kısmını getirir. Sayfayı parçalara ayırmak için kullanılır.
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialQuickContent()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            return PartialView();
        }
        public PartialViewResult PartialService()
        {//veriyle birlikte parçayı getirme
            var value = db.Service.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialSkill()
        {
            var value= db.Skill.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialAward()
        {
            return PartialView();
        }
        public PartialViewResult PartialTestimonial()
        {
            return PartialView();
        }
    }
}