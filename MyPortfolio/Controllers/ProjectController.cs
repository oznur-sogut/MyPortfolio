using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult ProjectIndex()
        {
            var value= db.Project.ToList();
            return View(value);
        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.Project.Find(id);
            db.Project.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProjectIndex");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
			List<SelectListItem> values = (from i in db.Category.ToList()
										  select new SelectListItem
										  {
											  Text = i.CategoryName,
											  Value = i.CategoryID.ToString()
										  }).ToList();
			ViewBag.Value = values;
			var value = db.Project.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(Project project)
        {
            var value = db.Project.Find(project.ProjectID);
            value.ProjectTitle = project.ProjectTitle;
            value.ProjectDescription = project.ProjectDescription;
            var values = db.Category.Where(x=>x.CategoryID==project.Category.CategoryID).FirstOrDefault();
                value.ProjectCategory=values.CategoryID;
           
            db.SaveChanges();
            return RedirectToAction("ProjectIndex");
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
			List<SelectListItem> value = (from i in db.Category.ToList()
										  select new SelectListItem
										  {
											  Text = i.CategoryName,
											  Value = i.CategoryID.ToString()
										  }).ToList();
            ViewBag.values=value;
			return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            var value = db.Category.Where(x=>x.CategoryID==project.Category.CategoryID).FirstOrDefault();
            project.Category = value;
            db.Project.Add(project);
            db.SaveChanges();
            return RedirectToAction("ProjectIndex");
        }
    }
}