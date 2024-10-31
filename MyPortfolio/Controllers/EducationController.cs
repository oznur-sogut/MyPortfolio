using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class EducationController : Controller
    {
        [Authorize]
        public ActionResult EducationIndex()
        {
            return View();
        }
    }
}