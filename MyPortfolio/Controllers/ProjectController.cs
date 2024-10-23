using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult ProjectIndex()
        {
            var value= db.Project.ToList();
            return View(value);
        }
    }
}