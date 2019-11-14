using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSepet.Controllers
{
    using Models;
    using MVCSepet.Models.MyEntities;
    using SingletonPattern;
    public class HomeController : Controller
    {
        NorthwindEntities db = DBTool.DBInstance;
        // GET: Home
        public ActionResult Login(string id)
        {
            if (id != null)
            {
                ViewBag.UyeOlmamissiniz = id;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee item)
        {
            if (db.Employees.Any(x => x.FirstName == item.FirstName && x.LastName == item.LastName))
            {
                Employee login = db.Employees.FirstOrDefault(x => x.FirstName == item.FirstName && x.LastName == item.LastName);

                Session["uye"] = login;

                return RedirectToAction("ShoppingList", "Product");
            }
            ViewBag.Mesaj = "Kullanıcı adı yanlış (Wrong Username or Password)";
            return View();
        }


    }
}