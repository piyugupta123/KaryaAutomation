using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KaryaAutomation.Models;

namespace KaryaAutomation.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegList()
        {
            return View();
        }


        public ActionResult SaveRegistration(RegistrationModel model)

        {
            try
            {
                return Json(new { Message = (new RegistrationModel().SaveRegistration(model)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetRegistration()
        {
            try
            {
                return Json(new { model = (new RegistrationModel().GetRegistration()) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult deleteRegistration(int id)
        {
            try
            {
                return Json(new { model = (new RegistrationModel().deleteRegistration(id)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}