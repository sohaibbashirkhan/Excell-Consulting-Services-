using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ExcellOnConsultingServices.Controllers
{
    public class AccountController : Controller
    {
        ExcellOnServiceEntities db = new ExcellOnServiceEntities();
        // GET: Account
        public ActionResult Index()
        {
            if (Session["pageopen"] != null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("Adminlogin");
            }
        }
        public ActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBranch(FormCollection fc)
        {
            String BranchName = Request.Form["BranchName"];
            String EmailAddress = Request.Form["EmailAddress"];
            String PhoneNumber = Request.Form["PhoneNumber"];
            String BranchAddress = Request.Form["BranchAddress"];
            String City = Request.Form["City"];


            Branch obj = new Branch();
            obj.BranchName = BranchName;
            obj.EmailAddress = EmailAddress;
            obj.PhoneNumber = PhoneNumber;
            obj.BranchAddress = BranchAddress;
            obj.City = City;
            db.Branches.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Branch");
        }
        public ActionResult Branch()
        {
            return View(db.Branches.ToList());
        }
        public ActionResult BranchDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var idata = db.Branches.Find(id);
            if (idata == null)
            {
                return HttpNotFound();

            }
            else
            {
                db.Branches.Remove(idata);
                db.SaveChanges();
                return RedirectToAction("Branch");
            }

        }
        public ActionResult BranchEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var iddate = db.Branches.Find(id);
            if (iddate == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(iddate);
            }

        }
        [HttpPost]
        public ActionResult BranchEdit()
        {
            int id = int.Parse(Request.Form["BranchID"]);
            String BranchName = Request.Form["BranchName"];
            String EmailAddress = Request.Form["EmailAddress"];
            String PhoneNumber = Request.Form["PhoneNumber"];
            String BranchAddress = Request.Form["BranchAddress"];
            String City = Request.Form["City"];

            Branch tblb = new Branch();
            tblb.BranchName = BranchName;
            tblb.EmailAddress = EmailAddress;
            tblb.PhoneNumber = PhoneNumber;
            tblb.BranchAddress = BranchAddress;
            tblb.City = City;
            tblb.BranchID = id;
            db.Entry(tblb).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Branch");
        }
   
        public ActionResult InboundServices()
        {
            return View(db.InboundServices.ToList());
        }

        public ActionResult OutboundServices()
        {
            return View(db.OutboundServices.ToList());
        }
        public ActionResult TeleMarketingServices()
        {
            return View(db.TeleMarketingServices.ToList());
        }
        //add services
        public ActionResult AddService()
        {
            return View();
        }
         [HttpPost]
        public ActionResult AddService(FormCollection fc ,HttpPostedFileBase Picture)
        {
            String Title = Request.Form["Title"];
            String ServiceType = Request.Form["ServiceType"];
            String Descriptions = Request.Form["Descriptions"];
            String Pictures = Request.Form["Picture"];
            //int Price = Request.Form [Price];
            int Price = int.Parse(Request.Form["Price"]);

            ProductService obj = new ProductService();
            obj.Title = Title;
            obj.ServiceType = ServiceType;
            obj.Descriptions = Descriptions;
            var pt = Path.GetFileNameWithoutExtension(Picture.FileName);
            var ex = Path.GetExtension(Picture.FileName);
             obj.Picture = pt + ex;
             Picture.SaveAs(@"E:\Aptech\ExcellOnConsultingServices\ExcellOnConsultingServices\Picture" + pt + ex);
            //obj.Picture = Picture;
            obj.Price = Price;
            db.ProductServices.Add(obj);
            db.SaveChanges();
            ViewBag.Picture = pt + ex;
            return RedirectToAction("ProductService");
        }
        
         public ActionResult ProductService()
         {
             return View(db.ProductServices.ToList());
         }
         public ActionResult ProductDelete(int? id)
         {
             if (id == null)
             {
                 return HttpNotFound();
             }
             var Product = db.ProductServices.Find(id);
             if (Product == null)
             {
                 return HttpNotFound();

             }
             else
             {
                 db.ProductServices.Remove(Product);
                 db.SaveChanges();
                 return RedirectToAction("ProductService");
             }

         }
         public ActionResult ProductEdit(int? id)
         {
             if (id == null)
             {
                 return HttpNotFound();

             }
             var Product = db.ProductServices.Find(id);
             if (Product == null)
             {
                 return HttpNotFound();
             }
             else
             {
                 return View(Product);
             }

         }
         [HttpPost]
         public ActionResult ProductEdit()
         {
             int id = int.Parse(Request.Form["ID"]);
             String Title = Request.Form["Title"];
             String ServiceType = Request.Form["ServiceType"];
             String Descriptions = Request.Form["Descriptions"];
             String Pictures = Request.Form["Picture"];
             //int Price = Request.Form [Price];
             int Price = int.Parse(Request.Form["Price"]);

             ProductService tbl = new ProductService();
             tbl.Title = Title;
             tbl.ServiceType = ServiceType;
             tbl.Descriptions = Descriptions;
             tbl.Picture = Pictures;
             //obj.Picture = Picture;
            tbl.Price = Price;
             tbl.ID = id;
             db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
             db.SaveChanges();
         return RedirectToAction("ProductService");
            
         }
   
         public ActionResult AddManagement()
         {
             return View();
         }
         [HttpPost]
         public ActionResult AddManagement(FormCollection fc)
         {
             String HRName = Request.Form["HRName"];
             String PhoneNo = Request.Form["PhoneNo"];
             String Email = Request.Form["Email"];
             String HRAddress = Request.Form["HRAddress"];


             HrManagement obj = new HrManagement();
             obj.HRName = HRName;
             obj.PhoneNo = PhoneNo;
             obj.Email = Email;
             obj.HRAddress = HRAddress;
             db.HrManagements.Add(obj);
             db.SaveChanges();
             return RedirectToAction("HrManagement");
         }

        public ActionResult HrManagement()
        {
            return View(db.HrManagements.ToList());
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var idata = db.HrManagements.Find(id);
            if (idata == null)
            {
                return HttpNotFound();

            }
            else
            {
                db.HrManagements.Remove(idata);
                db.SaveChanges();
                return RedirectToAction("HrManagement");
            }

        }
        public ActionResult HrEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var iddate = db.HrManagements.Find(id);
            if (iddate == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(iddate);
            }

        }
        [HttpPost]
        public ActionResult HrEdit()
        {
            int id = int.Parse(Request.Form["HRID"]);
            String HRName = Request.Form["HRName"];
            String PhoneNo = Request.Form["PhoneNo"];
            String Email = Request.Form["Email"];
            String HRAddress = Request.Form["HRAddress"];

            HrManagement tbl = new HrManagement();
            tbl.HRName = HRName;
            tbl.PhoneNo = PhoneNo;
            tbl.Email = Email;
            tbl.HRAddress = HRAddress;
            tbl.HRID = id;
            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("HrManagement");
        }
   
        public ActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminRegister(FormCollection fc)
        {

            String AdminName = Request.Form["AdminName"];
            String PhoneNo = Request.Form["PhoneNo"];
            String Email = Request.Form["Email"];
            String AdminPassword = Request.Form["AdminPassword"];


            Administration obj = new Administration();
            obj.AdminName = AdminName;
            obj.PhoneNo = PhoneNo;
            obj.Email = Email;
            obj.AdminPassword = AdminPassword;
            db.Administrations.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Administration");
        }
        public ActionResult Administration()
        {
            return View(db.Administrations.ToList());

        }
        public ActionResult AdminDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var idata = db.Administrations.Find(id);
            if (idata == null)
            {
                return HttpNotFound();

            }
            else
            {
                db.Administrations.Remove(idata);
                db.SaveChanges();
                return RedirectToAction("Administration");
            }

        }
        public ActionResult AdminEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var iddate = db.Administrations.Find(id);
            if (iddate == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(iddate);
            }

        }
        [HttpPost]
        public ActionResult AdminEdit()
        {
            int id = int.Parse(Request.Form["AdminID"]);
            String AdminName = Request.Form["AdminName"];
            String PhoneNo = Request.Form["PhoneNo"];
            String Email = Request.Form["Email"];
            String AdminPassword = Request.Form["AdminPassword"];

            Administration tbla = new Administration();
            tbla.AdminName = AdminName;
            tbla.PhoneNo = PhoneNo;
            tbla.Email = Email;
            tbla.AdminPassword = AdminPassword;
            tbla.AdminID = id;
            db.Entry(tbla).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Administration");
        }
        public ActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adminlogin(String Email, String AdminPassword)
        {
            var logincheck = db.Administrations.FirstOrDefault(e => e.Email == Email && e.AdminPassword == AdminPassword);
            if (logincheck != null)
            {
                Session["pageopen"] = logincheck.AdminName;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.loginerror = "Invalid eamil or password";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return View("Adminlogin");
        }

      
        public ActionResult AddTraining()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTraining(FormCollection fc ,HttpPostedFileBase Picture)
        {
            String Title = Request.Form["Title"];
            String Descriptions = Request.Form["Descriptions"];
            String Pictures = Request.Form["Picture"];
            String Duration = Request.Form["Duration"];
            String TrainingStatus = Request.Form["TrainingStatus"];


            Training obj = new Training();
            obj.Title = Title;
            obj.Descriptions = Descriptions;
            var pt = Path.GetFileNameWithoutExtension(Picture.FileName);
            var ex = Path.GetExtension(Picture.FileName);
            obj.Picture = pt + ex;
            Picture.SaveAs(@"E:\Aptech\ExcellOnConsultingServices\ExcellOnConsultingServices\traning\" + pt + ex);
            obj.Duration = Duration;
            obj.TrainingStatus = TrainingStatus;
            db.Trainings.Add(obj);
            db.SaveChanges();
            ViewBag.Picture = pt + ex;
            return RedirectToAction("Training");
        }
        public ActionResult Training()
        {
            return View(db.Trainings.ToList());
        }
        public ActionResult TrainingDelete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var idata = db.Trainings.Find(id);
            if (idata == null)
            {
                return HttpNotFound();

            }
            else
            {
                db.Trainings.Remove(idata);
                db.SaveChanges();
                return RedirectToAction("Training");
            }

        }
        public ActionResult TrainingEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            var Training = db.Trainings.Find(id);
            if (Training == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(Training);
            }

        }
        [HttpPost]
        public ActionResult TrainingEdit()
        {
            int id = int.Parse(Request.Form["ID"]);
            String Title = Request.Form["Title"];
            String Descriptions = Request.Form["Descriptions"];
            String Pictures = Request.Form["Picture"];
            String Duration = Request.Form["Duration"];
            //int Price = Request.Form [Price];
            String TrainingStatus =Request.Form["TrainingStatus"];

            Training tbls = new Training();
            tbls.Title = Title;
            tbls.Descriptions = Descriptions;
            tbls.Picture = Pictures;
            //obj.Picture = Picture;
            tbls.Duration = Duration;
            tbls.TrainingStatus = TrainingStatus;
            tbls.ID = id;
            db.Entry(tbls).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Training");

        }
      
       
        public ActionResult Contact()
        {
            return View(db.Contacts.ToList());
        }

        

    }
}