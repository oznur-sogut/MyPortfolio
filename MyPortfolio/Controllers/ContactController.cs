﻿using MyPortfolio.Models;
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
            //firstordefault bulduğu ilk değeri getirir.
            ViewBag.description= db.Address.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone= db.Address.Select(x => x.Phone).FirstOrDefault();
            ViewBag.addressDetail= db.Address.Select(x => x.AddressDetail).FirstOrDefault();
            ViewBag.mail=db.Address.Select(x=>x.Mail).FirstOrDefault();
            return View();
        }
        [HttpPost]
        
        public ActionResult ContactIndex(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index", "Default"); 
        }
    }
}