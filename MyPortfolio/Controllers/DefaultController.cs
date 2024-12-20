﻿using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        //partialView--> sayfanın bütününü parçalar az bir kısmını getirir. Sayfayı parçalara ayırmak için kullanılır.
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialQuickContent()
        {
            ViewBag.name= db.About.Select(x=>x.NameSurname).FirstOrDefault();
            ViewBag.description=db.About.Select(x=>x.Description).FirstOrDefault();
            ViewBag.phone=db.Address.Select(x=>x.Phone).FirstOrDefault();
            ViewBag.mail=db.Address.Select(x=>x.Mail).FirstOrDefault();
            var value= db.SocialMedia.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.introduction=db.About.Select(x=>x.Introduction).FirstOrDefault();
            ViewBag.name=db.About.Select(x=>x.NameSurname).FirstOrDefault();
            ViewBag.title=db.About.Select(x=>x.Title).FirstOrDefault();
            ViewBag.description=db.About.Select(x=>x.Description).FirstOrDefault();
            ViewBag.image=db.About.Select(x=>x.AboutImage).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialSocial()
        {
            var value= db.SocialMedia.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialService()
        {//veriyle birlikte parçayı getirme
            var value = db.Service.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialSkill()
        {
            var value= db.Skill.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialAward()
        {
            ViewBag.title = db.MyEducation.Select(x => x.EducationTitle).FirstOrDefault();
            ViewBag.subtitle = db.MyEducation.Select(x => x.EducationSubTitle).FirstOrDefault();
            var value =db.MyCertificate.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialTestimonial()
        {
            var value= db.Testimonial.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult PartialContact()
        {
			ViewBag.description = db.Address.Select(x => x.Description).FirstOrDefault();
			ViewBag.phone = db.Address.Select(x => x.Phone).FirstOrDefault();
			ViewBag.addressDetail = db.Address.Select(x => x.AddressDetail).FirstOrDefault();
			ViewBag.mail = db.Address.Select(x => x.Mail).FirstOrDefault();
			return PartialView();
		}
        [HttpPost]
		public PartialViewResult PartialContact(Contact contact)
		{
			db.Contact.Add(contact);
			db.SaveChanges();
            return PartialView();
		}
		public PartialViewResult PartialStatisticAndProject()
        {
            ViewBag.skill=db.Skill.Select(x=> x.SkillID).Count();
            ViewBag.service=db.Service.Select(x=> x.ServiceID).Count();
            var value= db.Project.ToList();
            return PartialView(value);
        }
    }
}