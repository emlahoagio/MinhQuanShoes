using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string username, string password)
        {
            ViewData["username"] = username;
            bool success = Admin.CheckLogin(username, password);
                if (success)
            {
                Session["username"] = username;
                return RedirectToAction("Index", "Home");
            }else
            {
                ViewData["Message"] = "Incorrect user or pass";
                if (Session["username"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
        }
        public ActionResult Clear()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        
    }
}