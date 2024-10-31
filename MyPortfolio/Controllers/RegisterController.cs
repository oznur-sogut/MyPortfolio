using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class RegisterController : Controller
    {
        MyPortfolioDbEntities db= new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult RegisterIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterIndex(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("LoginIndex","Login");
        }
    }
}