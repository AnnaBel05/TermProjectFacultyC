using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TermProjectFacultyC.Models;

namespace TermProjectFacultyC.Controllers
{
    public class LoginController : Controller
    {
        private facultyEntities3 db = new facultyEntities3();
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(userinfo userinfoObj)
        {
            using (db)
            {
                db.userinfo.Add(userinfoObj);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            using (db)
            {
                var user = db.userinfo.Where(a => a.email == login.Email && a.password == login.Password).FirstOrDefault();
                if (user != null)
                {
                    var Ticket = new FormsAuthenticationTicket(login.Email, true, 3000);
                    string Encrypt = FormsAuthentication.Encrypt(Ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                    cookie.Expires = DateTime.Now.AddHours(3000);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}