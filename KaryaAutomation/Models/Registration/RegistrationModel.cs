using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KaryaAutomation.Data;

namespace KaryaAutomation.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Mobile_Number { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public String SaveRegistration(RegistrationModel model)
        {
            string msg = "";
            KaryaAutomationEntities db = new KaryaAutomationEntities();
            var savereg = new tblRegistration()
            {
                Name = model.Name,
                Address = model.Address,
                Gender = model.Gender,
                City = model.City,
                Mobile_Number = model.Mobile_Number,
                Pincode = model.Pincode,
                State = model.State,
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,




            };
            db.tblRegistrations.Add(savereg);
            db.SaveChanges();
            return msg;

        }
        public List<RegistrationModel> GetRegistration()
        {

            KaryaAutomationEntities Db = new KaryaAutomationEntities();
            List<RegistrationModel> lstRegistration = new List<RegistrationModel>();
            var AddRegistration = Db.tblRegistrations.ToList();
            if (AddRegistration != null)
            {
                foreach (var Registration in AddRegistration)
                {
                    lstRegistration.Add(new RegistrationModel()

                    {
                        Id = Registration.Id,
                        Name = Registration.Name,
                        Address = Registration.Address,
                        Gender = Registration.Gender,
                        City = Registration.City,
                        Mobile_Number = Registration.Mobile_Number,
                        Pincode = Registration.Pincode,
                        State = Registration.State,
                        Email = Registration.Email,
                        Password = Registration.Password,
                        ConfirmPassword = Registration.ConfirmPassword,
                    });
                }
            }
            return lstRegistration;
        }

        public string deleteRegistration(int id)
        {
            string Message = "";
            KaryaAutomationEntities Db = new KaryaAutomationEntities();
            var deleteRecord = Db.tblRegistrations.Where(p => p.Id == id).FirstOrDefault();
            if (deleteRecord != null)
            {
                Db.tblRegistrations.Remove(deleteRecord);
            };
            Db.SaveChanges();
            Message = "Record Deleted Successfully";
            return Message;
        }
    }
}
    

