using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioDbEntities db= new MyPortfolioDbEntities();
        [Authorize]
        public ActionResult TestimonialIndex()
        {
            var value = db.Testimonial.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            db.Testimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("TestimonialIndex");
        }
		// id nin zorunluluğu routConfigten gelir
		public ActionResult DeleteTestimonial(int id)
        {
            var value = db.Testimonial.Find(id);
            db.Testimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("TestimonialIndex");

        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value= db.Testimonial.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial (Testimonial testimonial)
        {
            var value= db.Testimonial.Find(testimonial.TestimonialID);
            value.TestimonialNameSurname= testimonial.TestimonialNameSurname;
            value.TestimonialTitle=testimonial.TestimonialTitle;
            value.TestimonialImageUrl=testimonial.TestimonialImageUrl;
            value.TestimonialComment=testimonial.TestimonialComment;
            db.SaveChanges();
            return RedirectToAction("TestimonialIndex");
        }
    }
}