using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KaryaAutomation.Data;

namespace KaryaAutomation.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }


        public String SaveContact(ContactModel model)
        {
            string msg = "";
            KaryaAutomationEntities db = new KaryaAutomationEntities();
            var savecontact = new tblContact()
            {
                Full_Name = model.Full_Name,
                Phone_Number = model.Phone_Number,
                Email = model.Email,
                Message = model.Message,
                




            };
            db.tblContacts.Add(savecontact);
            db.SaveChanges();
            return msg;

        }

        public List<ContactModel> GetContact()

        {
            KaryaAutomationEntities db = new KaryaAutomationEntities();

            List<ContactModel> lstTechnical = new List<ContactModel>();
            var AddContact = db.tblContacts.ToList();
            if (AddContact != null)

            {
                foreach (var Technical in AddContact)
                {
                    lstTechnical.Add(new ContactModel()

                    {
                        Id = Technical.Id,
                        Full_Name = Technical.Full_Name,
                        Phone_Number = Technical.Phone_Number,
                        Email = Technical.Email,
                        Message = Technical.Message,
                    });
                }
            }
            return lstTechnical;
        }
    }
}