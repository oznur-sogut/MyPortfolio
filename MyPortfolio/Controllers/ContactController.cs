using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    
    public class ContactController : Controller
    {
		MyPortfolioDbEntities db = new MyPortfolioDbEntities();
		[HttpGet]
        public ActionResult ContactIndex()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult ContactIndex(string a)
        {
            return View(); 
        }
    }
}