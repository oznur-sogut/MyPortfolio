using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        [Authorize]
        public ActionResult CategoryIndex()
        {
            var value= db.Category.ToList();
            return View(value);
        }
        public ActionResult DeleteCategory(int id)
        {
            var value=db.Category.Find(id);
            db.Category.Remove(value);
            db.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        [HttpGet]
        public ActionResult UpdateCategory( int id)
        {
            var value = db.Category.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = db.Category.Find(category.CategoryID);
            value.CategoryID = category.CategoryID;
            value.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
    }
}