using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KaryaAutomation.Data;
using System.IO;

namespace KaryaAutomation.Models
{
    public class GalleryModel
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }

        public string SaveGallery(HttpPostedFileBase fb, GalleryModel model)
        {
            string msg = "Uploaded Successfully";

            KaryaAutomationEntities Db = new KaryaAutomationEntities();
            string filePath = "";
            string fileName = "";
            string sysFileName = "";

            if (fb != null && fb.ContentLength > 0)
            {
                filePath = HttpContext.Current.Server.MapPath("~/Content/img/");

                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/img/") + "/" + sysFileName;
                }
            }

            {

                KaryaAutomationEntities db = new KaryaAutomationEntities();
                //var getCatData = Db.tblGalleries.Where(p => p.Id == model.Id).FirstOrDefault();
                //if (getCatData == null)
                //ProductModel model = new ProductModel();
                {
                    var savegallery = new tblGallery()
                    {
                        Title = model.Title,
                        Photo = sysFileName,
                       

                    };
                    Db.tblGalleries.Add(savegallery);
                    Db.SaveChanges();
                    return msg;
                }

            }
        }
        public List<GalleryModel> GetGallery()
        {

            KaryaAutomationEntities Db = new KaryaAutomationEntities();
            List<GalleryModel> lstGallery = new List<GalleryModel>();
            var AddGallery = Db.tblGalleries.ToList();
            if (AddGallery != null)
            {
                foreach (var Gallery in AddGallery)
                {
                    lstGallery.Add(new GalleryModel()

                    {
                        Id = Gallery.Id,
                        Photo = Gallery.Photo,
                        Title=Gallery.Title,
                       
                    });
                }
            }
            return lstGallery;
        }

        public string Deletegallary(int Id)
        {
            string Message = "";
            KaryaAutomationEntities Db = new KaryaAutomationEntities();
            var Deletegallary = Db.tblGalleries.Where(p => p.Id == Id).FirstOrDefault();
            if (Deletegallary != null)
            {
                Db.tblGalleries.Remove(Deletegallary);
            };
            Db.SaveChanges();
            Message = "Record Deleted Successfully";
            return Message;
        }
    }
}
    
