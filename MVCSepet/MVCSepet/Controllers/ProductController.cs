using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSepet.Controllers
{
    using Models;
    using MVCSepet.AuthenticationClass;
    using MVCSepet.Models.MyEntities;
    using SingletonPattern;
    public class ProductController : Controller
    {
        NorthwindEntities db = DBTool.DBInstance;
        public ActionResult ShoppingList()
        {
            return View(db.Products.ToList());
        }

        //[EmployeeAuthentication]
        public ActionResult AddToCart(int id)
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Product eklenecekUrun = db.Products.Find(id);

            CartItem ci = new CartItem();
            ci.ID = eklenecekUrun.ProductID;
            ci.Name = eklenecekUrun.ProductName;
            ci.Price = eklenecekUrun.UnitPrice;

            c.SepeteEkle(ci);

            Session["scart"] = c;

            return RedirectToAction("ShoppingList");

        }


        //[EmployeeAuthentication]

        public ActionResult SepetSayfasi()
        {
            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                return View(c);
            }
            ViewBag.SepetBos = "Sepetinizde ürün bulunmamaktadır!";

            return View();
        }

        //[EmployeeAuthentication]
        public ActionResult Delete(int id)
        {
            Cart c = Session["scart"] as Cart;
            c.SepettenSil(id);

            return RedirectToAction("SepetSayfasi");
        }

        public ActionResult Update(int id)
        {
            Cart c = Session["scart"] as Cart;

            CartItem ci = c.Sepetim.Find(x => x.ID == id);

            return View(ci);
        }

        [HttpPost]
        public ActionResult Update(CartItem item)
        {
            Cart c = Session["scart"] as Cart;
            CartItem guncellenen = c.Sepetim.Find(x => x.ID == item.ID);
            guncellenen.Amount = item.Amount;
            return RedirectToAction("SepetSayfasi");
        }


    }
}