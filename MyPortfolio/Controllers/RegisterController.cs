using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult RegisterIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterIndex(string a)
        {
            return View();
        }
    }
}