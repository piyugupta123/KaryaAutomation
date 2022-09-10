using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KaryaAutomation.Models;

namespace KaryaAutomation.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GalleryList()
        {
            return View();
        }

        public ActionResult AdminGalleryList()
        {
            return View();
        }

        public ActionResult SaveGallery(GalleryModel model)

        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { model = (new GalleryModel().SaveGallery(fb, model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetGallery()
        {
            try
            {
                return Json(new { model = (new GalleryModel().GetGallery()) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Deletegallary(int Id)
        {
            try
            {
                return Json(new { model = (new GalleryModel().Deletegallary(Id)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
    
