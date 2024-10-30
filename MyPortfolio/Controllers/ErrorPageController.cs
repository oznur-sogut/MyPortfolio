using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Page404()
        {
            //Sayfa durum kodu.404 yanıtı 
            Response.StatusCode = 404;
            return View();
        }
    }
}