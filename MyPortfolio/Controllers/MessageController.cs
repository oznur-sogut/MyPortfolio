using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioDbEntities db= new MyPortfolioDbEntities();
        [Authorize]
        public ActionResult MessageIndex()
        {
            var value= db.Contact.ToList();
            return View(value);
        }
        public ActionResult DeleteMessage(int id)
        {
            var value=db.Contact.Find(id);
            db.Contact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("MessageIndex");
        }
        public ActionResult MessageDetail(int id)
        {
            var value=db.Contact.Find(id);;
            return View(value);
        }
    }
}