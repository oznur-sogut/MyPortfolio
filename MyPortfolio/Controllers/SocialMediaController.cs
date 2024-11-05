using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioDbEntities db= new MyPortfolioDbEntities();
        [Authorize]
        public ActionResult SocialIndex()
        {
            var value = db.SocialMedias.ToList();
            return View(value);
        }
        public ActionResult DeleteSocial(int id)
        {
            var value= db.SocialMedias.Find(id);
            db.SocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SocialIndex");
        }
        [HttpGet]
        public ActionResult CreateSocial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocial(SocialMedias socialMedia)
        {
            db.SocialMedias.Add(socialMedia);
            db.SaveChanges();
            return RedirectToAction("SocialIndex");
        }
        [HttpGet]
        public ActionResult UpdateSocial(int id)
        {
            var value = db.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocial(SocialMedias socialMedias)
        {
            var value = db.SocialMedias.Find(socialMedias.SocialID);
            value.SocialName = socialMedias.SocialName;
            value.SocialUrl = socialMedias.SocialUrl;
            value.SocialIcon = socialMedias.SocialIcon;
            db.SaveChanges();
            return RedirectToAction("SocialIndex");
        }
    }
}