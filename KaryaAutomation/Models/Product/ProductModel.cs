using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KaryaAutomation.Data;
using System.IO;

namespace KaryaAutomation.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string SaveProduct(HttpPostedFileBase fb, ProductModel model)
        {
            string msg = "Registration Successfully";

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
                //var getCatData = Db.tblProducts.Where(p => p.Id == model.Id).FirstOrDefault();
                //if (getCatData == null)
                //ProductModel model = new ProductModel();
                {
                    var saveproduct = new tblProduct()
                    {
                        Title = model.Title,
                        Image = sysFileName,
                        Description = model.Description,
                        Price = model.Price,

                    };
                    Db.tblProducts.Add(saveproduct);
                    Db.SaveChanges();
                    return msg;
                }

                //else
                //{
                //    getCatData.Title=model.Title;
                //    getCatData.Image=sysFileName;
                //    getCatData.Description=model.Description;
                //    getCatData.Price=model.Price;
                //};

                //Db.SaveChanges();
                //msg= "Updated Sucessfully";

                //return msg;


            }
        }

            public List<ProductModel>GetProduct()

            {

                KaryaAutomationEntities db = new KaryaAutomationEntities();
                List<ProductModel> lstTechnical = new List<ProductModel>();
                var AddProduct = db.tblProducts.ToList();
                if (AddProduct!= null)

                {
                    foreach (var Technical in AddProduct)
                    {
                        lstTechnical.Add(new ProductModel()

                        {
                            Id=Technical.Id,
                            Title=Technical.Title,
                            Image=Technical.Image,
                            Description=Technical.Description,
                            Price=Technical.Price,
                        });




                    }


                }
                return lstTechnical;
            }
        
    }
}
        
    






