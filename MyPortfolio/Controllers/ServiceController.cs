using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        MyPortfolioDbEntities db =new MyPortfolioDbEntities();
        [Authorize]
        public ActionResult ServiceIndex()
        {
            var value= db.Service.ToList();
            return View(value);
        }
        public ActionResult DeleteService(int id)
        {
            var value = db.Service.Find(id);
            db.Service.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ServiceIndex");
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            db.Service.Add(service);
            db.SaveChanges();
            return RedirectToAction("ServiceIndex");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value=db.Service.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = db.Service.Find(service.ServiceID);
            value.ServiceName = service.ServiceName;
            db.SaveChanges();
            return RedirectToAction("ServiceIndex");
        }
    }
}