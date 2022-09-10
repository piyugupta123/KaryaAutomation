using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KaryaAutomation.Models;

namespace KaryaAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            return View();
        }

        public ActionResult Productone()
        {
            return View();
        }

        public ActionResult Producttwo()
        {
            return View();
        }

        public ActionResult Productthree()
        {
            return View();
        }

        public ActionResult Productfour()
        {
            return View();
        }

        public ActionResult Productfive()
        {
            return View();
        }

        public ActionResult Productsix()
        {
            return View();
        }

        public ActionResult ProductPage()
        {
            return View();
        }


        public ActionResult SaveProduct(ProductModel model)

        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { model = (new ProductModel().SaveProduct(fb, model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetProduct()
        {
            try
            {
                return Json(new { model = (new ProductModel().GetProduct()) },
                    JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}