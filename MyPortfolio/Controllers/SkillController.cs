using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        [Authorize]
        public ActionResult SkillIndex()
        {
            var value= db.Skill.ToList();
            return View(value);
        }
    }
}