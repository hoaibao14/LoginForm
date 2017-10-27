using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Table usr)
        { 
            if (ModelState.IsValid)
            {
                using (UserInfoEntities uie = new UserInfoEntities())
                {
                    var v = uie.Tables.Where(a => a.Username.Equals(usr.Username) && a.Password.Equals(usr.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UserID.ToString();
                        Session["LogedUserFullname"] = v.Fullname.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(usr);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
            
        }
    }
}
