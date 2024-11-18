using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CertificateController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        [Authorize]
        public ActionResult CertificateIndex()
        {
            var value= db.MyCertificate.ToList();
            return View(value);
        }
        public ActionResult DeleteCertificate(int id)
        {
            var value=db.MyCertificate.Find(id);
            db.MyCertificate.Remove(value);
            db.SaveChanges();
            return RedirectToAction("CertificateIndex");
        }
        [HttpGet]
        public ActionResult UpdateCertificate (int id)
        {
            var value = db.MyCertificate.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(MyCertificate myCertificate)
        {
            var value = db.MyCertificate.Find(myCertificate.CertificateID);
            value.CertificateName= myCertificate.CertificateName;
            value.CertificateLocation= myCertificate.CertificateLocation;
            value.CertificateYear= myCertificate.CertificateYear;
            db.SaveChanges();
            return RedirectToAction("CertificateIndex");
        }
        [HttpGet]
        public ActionResult CreateCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCertificate(MyCertificate myCertificate)
        {
            db.MyCertificate.Add(myCertificate);
            db.SaveChanges();
            return RedirectToAction("CertificateIndex");
        }
    }
}