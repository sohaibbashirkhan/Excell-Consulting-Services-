using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcellOnConsultingServices.Controllers
{
    public class HomeController : Controller
    {
        ExcellOnServiceEntities db = new ExcellOnServiceEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUS(FormCollection fc)
        {

            String Username = Request.Form["Username"];
            String PhoneNo = Request.Form["PhoneNo"];
            String Email = Request.Form["Email"];
            String ContactMessage = Request.Form["ContactMessage"];


            Contact obj = new Contact();
            obj.Username = Username;
            obj.PhoneNo = PhoneNo;
            obj.Email = Email;
            obj.ContactMessage = ContactMessage;
            db.Contacts.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Services()
        {
            return View(db.ProductServices.ToList());
        }

        public ActionResult InboundServices()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InboundServices(FormCollection fc)
        {
            String ServiceName = Request.Form["ServiceName"];
            String Cnic = Request.Form["Cnic"];
            String PhoneNo = Request.Form["PhoneNo"];
            String Email = Request.Form["Email"];
            String Country = Request.Form["Country"];
            String ServiceType = Request.Form["ServiceType"];
            int Price = int.Parse(Request.Form["Price"]);

            InboundService obj = new InboundService();
            obj.ServiceName = ServiceName;
            obj.Cnic = Cnic;
            obj.PhoneNo = PhoneNo;
            obj.Email = Email;
            obj.Country = Country;
            obj.ServiceType = ServiceType;
            obj.Price = Price;
            db.InboundServices.Add(obj);
            db.SaveChanges();
            return RedirectToAction("InboundServices");
        }

        public ActionResult OutboundServices()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OutboundServices(FormCollection fc)
        {
            String ServiceName = Request.Form["ServiceName"];
            String Cnic = Request.Form["Cnic"];
            String City = Request.Form["City"];
            String PhoneNo = Request.Form["PhoneNo"];
            String Email = Request.Form["Email"];
            String Country = Request.Form["Country"];
            String ServiceType = Request.Form["ServiceType"];
            String UserExperience = Request.Form["UserExperience"];
            int Price = int.Parse(Request.Form["Price"]);

            OutboundService obj = new OutboundService();
            obj.ServiceName = ServiceName;
            obj.Cnic = Cnic;
            obj.City = City;
            obj.PhoneNo = PhoneNo;
            obj.Email = Email;
            obj.Country = Country;
            obj.ServiceType = ServiceType;
            obj.UserExperience = UserExperience;
            obj.Price = Price;
            db.OutboundServices.Add(obj);
            db.SaveChanges();
            return RedirectToAction("OutboundServices");
        }
        public ActionResult TaleMarketingServices()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaleMarketingServices(FormCollection fc)
        {
            String ServiceName = Request.Form["ServiceName"];
            String Cnic = Request.Form["Cnic"];
            String City = Request.Form["City"];
            String PhoneNo = Request.Form["PhoneNo"];
            String Email = Request.Form["Email"];
            String Country = Request.Form["Country"];
            String ServiceType = Request.Form["ServiceType"];
            String UserStatus = Request.Form["UserStatus"];
            int Price = int.Parse(Request.Form["Price"]);

            TeleMarketingService obj = new TeleMarketingService();
            obj.ServiceName = ServiceName;
            obj.Cnic = Cnic;
            obj.City = City;
            obj.PhoneNo = PhoneNo;
            obj.Email = Email;
            obj.Country = Country;
            obj.ServiceType = ServiceType;
            obj.UserStatus = UserStatus;
            obj.Price = Price;
            db.TeleMarketingServices.Add(obj);
            db.SaveChanges();
            return RedirectToAction("TaleMarketingServices");
        }

        public ActionResult Training()
        {
            return View(db.Trainings.ToList());
        }


    }
}