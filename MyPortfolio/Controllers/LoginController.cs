using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    public class LoginController : Controller
    {
        MyPortfolioDbEntities db= new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(Admin admin)
        {
            var value = db.Admin.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.Password == admin.Password);
            if (value != null) 
            {
                //Mvc de session(oturum) yönetimi setAuthacookie metodu ile sağlanır.beni hatırla işlemlerini true olunca hatırlar false olursa hatırlamaz.
                FormsAuthentication.SetAuthCookie(value.AdminUserName, false);
                //value dan gelen AdminUserNameini string olarak saklar. bir değişkene atar. Kimin ne yaptığı işlemi belirleme gibi
                Session["username"]=value.AdminUserName.ToString();
                return RedirectToAction("ServiceIndex","Service");
            }
            return View();
        }
    }
}