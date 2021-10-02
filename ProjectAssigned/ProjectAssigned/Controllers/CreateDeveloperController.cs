using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;



using System.IO;
using ProjectAssigned.Models;
using System.Net;
using System.Data.Entity;

namespace ProjectAssigned.Controllers
{
    
    public class CreateDeveloperController : Controller
    {
        ProjectAssignedEntities db=new ProjectAssignedEntities();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult AddDeveloper()
        {
            return View();
        }
        public ActionResult DeveloperList()
        {


            return View(db.AspNetUsers.ToList());
        }
        [HttpPost]
        public ActionResult AddDeveloper(AspNetUser model)
        {

            if (model.Picture != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.Picture.FileName);
                string extension = Path.GetExtension(model.Picture.FileName);
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                {
                    if (model.Picture.ContentLength < 1000000)
                    {
                        fileName = fileName + Guid.NewGuid().ToString() + extension;
                        model.Photo = fileName;
                        model.Picture.SaveAs(Path.Combine(Server.MapPath("~/Content/Filesdata/Images/"), fileName));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Picture must be less than 5kb");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Only png,jpg and jpeg formats are allowed.");
                    return View(model);
                }

            }
            if (model.cvfile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.cvfile.FileName);
                string extension = Path.GetExtension(model.cvfile.FileName);
                if (extension.ToLower() == ".doc" || extension.ToLower() == ".txt")
                {
                    if (model.cvfile.ContentLength < 1000)
                    {
                        fileName = fileName + Guid.NewGuid().ToString() + extension;
                        model.CV = fileName;
                        model.cvfile.SaveAs(Path.Combine(Server.MapPath("~/Content/Filesdata/Cv/"), fileName));
                    }
                    else
                    {
                        ModelState.AddModelError("", "file must be less than one mb ");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Only text,doc file allow");
                    return View(model);
                }

            }

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, Address = model.Address, FirstName = model.FirstName, LastName = model.LastName, IsActive = model.IsActive, PhoneNumber = model.PhoneNumber, Experience = model.Experience, Photo = model.Photo, CV = model.CV, JoinDate = model.JoinDate, Salary = model.Salary, Bio = model.Bio, Designation = model.Designation };
            var result = UserManager.Create(user, model.PasswordHash);
            if (result.Succeeded)
            {
                UserManager.AddToRoles(user.Id, "Developer");
                //TempData["Message"] = "Success : Doctor has been added successfully";
                //string profileName = user.FirstName + " " + (String.IsNullOrEmpty(user.LastName) ? string.Empty : user.LastName);
                //(new GenericModel()).FetchUserProfile().activityLog("Doctor creation", "<b>Profile of '" + profileName + "'</b> has been created", user.Id, "AspNetUser");
                var password = model.PasswordHash;
                var userName = model.UserName;
                bool isSent = SendEmail(user.Email,"Account Details", "Your account Username is:" + userName + "<br> Your password is:" + password + "");
                return View("DeveloperList");
            }
            else { 
                AddErrors(result);
            }
            //string errorMessage = "";
            //foreach (var error in result.Errors)
            //{
            //    //ModelState.AddModelError("", error);
            //    errorMessage += error + "\n";
            //}
            //        (new GenericModel()).FetchUserProfile().activityLog("Doctor creation", "<b>Profile creation</b> has been failed", 0, "AspNetUser");
            //List<DropDown> lstGender = new List<DropDown>();
            //lstGender.Add(new DropDown() { ID = 1, Name = "Male" });
            //lstGender.Add(new DropDown() { ID = 2, Name = "Female" });
            //model.lstGender = lstGender;
            //model.lstSpecialization = new SpecializationLogic().GetSpecialization();
            //TempData["Message"] = errorMessage;
            //return View(model);

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error);

            }
        }

        public static bool SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.EnableSsl = true;
                client.Port = Convert.ToInt32(WebConfigurationManager.AppSettings["Port"]);
                client.Host = WebConfigurationManager.AppSettings["ServerHost"];
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["Email"], WebConfigurationManager.AppSettings["Password"]);
                mailMessage.From = new MailAddress(WebConfigurationManager.AppSettings["DisplayEmail"].ToString(), WebConfigurationManager.AppSettings["DisplayName"]);
                if (!String.IsNullOrEmpty(toEmail))
                {
                    toEmail.Split(',').ToList().ForEach(x =>
                    {
                        if (!String.IsNullOrWhiteSpace(x))
                            mailMessage.To.Add(new MailAddress(x));
                    });
                }
                //if (!String.IsNullOrEmpty(emailTemplate.CC))
                //{
                //    emailTemplate.CC.Split(',').ToList().ForEach(x =>
                //    {
                //        if (!String.IsNullOrWhiteSpace(x))
                //            mailMessage.CC.Add(new MailAddress(x));
                //    });
                //}
                //if (!String.IsNullOrEmpty(emailTemplate.BCC))
                //{
                //    emailTemplate.BCC.Split(',').ToList().ForEach(x =>
                //    {
                //        if (!String.IsNullOrWhiteSpace(x))
                //            mailMessage.Bcc.Add(new MailAddress(x));
                //    });
                //}
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;// emailTemplate.Subject;
                mailMessage.Body = body;// emailTemplate.MessageBody;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }






    }
}

//string extension;
//string fileName;
//string uploadUrl;

//GET: CreateDeveloper

//public ActionResult DeveloperList()
//{
//    return View(db.CreateDevelopers.ToList());
//}
//public ActionResult AddDeveloper()
//{
//    return View();
//}


//public ActionResult AddDeveloper(CreateDeveloper create, HttpPostedFileBase Dp, HttpPostedFileBase cvdata)
//{


//    try
//    {

//        upload cv file
//        if (cvdata != null)
//        {
//            extension = Path.GetExtension(cvdata.FileName);
//            if (extension.ToLower() == ".doc" || extension.ToLower() == ".docx" || extension.ToLower() == ".txt")
//            {
//                if (cvdata.ContentLength < 1000000)
//                {
//                    fileName = Guid.NewGuid().ToString() + extension;
//                    uploadUrl = Server.MapPath("~/Content/Filesdata/Cv/");
//                    create.Cv = "~/Content/Filesdata/Cv/" + fileName;
//                    cvdata.SaveAs(Path.Combine(uploadUrl, fileName));
//                }
//                else
//                {
//                    ModelState.AddModelError("", "file size must be less than 2 mb");

//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "File must b doc,docx and text");
//                return View(create);
//            }
//        }
//        Dp Upload code
//        if (Dp != null)
//        {
//            extension = Path.GetExtension(Dp.FileName);
//            if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
//            {
//                if (Dp.ContentLength < 500)
//                {
//                    fileName = Guid.NewGuid().ToString() + extension;
//                    uploadUrl = Server.MapPath("~/Content/Filesdata/Images/");
//                    create.Image = "~/Content/Filesdata/Images/" + fileName;
//                    Dp.SaveAs(Path.Combine(uploadUrl, fileName));

//                }
//                else
//                {
//                    ModelState.AddModelError("", "Image must b less than 5 kb");
//                    return View(create);
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "image must b png jpg and jpeg");
//                return View(create);
//            }
//        }

//        add record in the Db

//        db.CreateDevelopers.Add(create);
//        db.SaveChanges();
//        ModelState.Clear();
//        return RedirectToAction("DeveloperList");

//    }
//    catch (Exception ex)
//    {
//        ModelState.AddModelError("", ex.Message);
//    }
//    return View(create);





//}



//Edit Get
//public ActionResult EditDeveloper(int? id)
//{
//    CreateDeveloper create = new CreateDeveloper();


//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    if (id != null)
//    {

//        create = db.CreateDevelopers.Where(model => model.Developer_Id == id).FirstOrDefault<CreateDeveloper>();

//    }

//    return View(create);
//}

/*public*/
//ActionResult EditDeveloper(CreateDeveloper create, HttpPostedFileBase Dp, HttpPostedFileBase cvdata)
//{

//    try
//    {
//        upload cv file
//        if (cvdata != null)
//        {
//            extension = Path.GetExtension(cvdata.FileName);
//            if (extension.ToLower() == ".doc" || extension.ToLower() == ".docx" || extension.ToLower() == ".txt")
//            {
//                if (cvdata.ContentLength < 1000000)
//                {
//                    fileName = Guid.NewGuid().ToString() + extension;
//                    uploadUrl = Server.MapPath("~/Content/Filesdata/Cv/");
//                    create.Cv = "~/Content/Filesdata/CV/" + fileName;
//                    if (!String.IsNullOrEmpty(create.Image))
//                    {
//                        if (System.IO.File.Exists(uploadUrl + "/" + create.Cv))
//                        {
//                            System.IO.File.Delete(uploadUrl + "/" + create.Cv);

//                        }
//                    }
//                    cvdata.SaveAs(Path.Combine(uploadUrl, fileName));

//                }
//                else
//                {
//                    ModelState.AddModelError("", "file must b less than 1 Mb");
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "File  must b doc , docx, txt");
//            }
//        }
//        Dp Upload code
//        if (Dp != null)
//        {
//            extension = Path.GetExtension(Dp.FileName);
//            if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
//            {
//                if (Dp.ContentLength < 500000)
//                {

//                    uploadUrl = Server.MapPath("~/Content/Filesdata/Images/");
//                    fileName = Guid.NewGuid().ToString() + extension;
//                    create.Image = "~/Content/Filesdata/Images/" + fileName;

//                    if (!String.IsNullOrEmpty(create.Image))
//                    {
//                        if (System.IO.File.Exists(uploadUrl + "/" + create.Image))
//                        {
//                            System.IO.File.Delete(uploadUrl + "/" + create.Image);

//                        }
//                    }

//                    Dp.SaveAs(Path.Combine(uploadUrl, fileName));

//                }
//                else
//                {
//                    ViewBag.message = "Picture size must be less than 2 mb";
//                    return View(" AddDeveloper");
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "Picture must be png, jpg or jpeg");


//            }
//        }

//        add record in the Db

//        db.Entry(create).State = EntityState.Modified;
//        db.SaveChanges();

//        return RedirectToAction("DeveloperList");
//    }
//    catch (Exception ex)
//    {
//        ModelState.AddModelError("", "Somthing went wrong");
//    }



//    return View(create);
//}

////public JsonResult IsUserExists(string Username, string UserPassword, string Email, string Phone, string prevemail, string prevpass, string prevname, string prephone)
////{
////    try
////    {
////        if (Username == prevname || Email == prevemail || UserPassword == prevpass || Phone == prephone)
////        {
//            return Json(true, JsonRequestBehavior.AllowGet);

//        }
//        return Json(!db.Asp.Any(x => x.Username == Username || x.UserPassword == UserPassword || x.Email == Email || x.Phone == Phone), JsonRequestBehavior.AllowGet);
//        check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

//    }
//    catch (Exception)
//    {

//        return Json(true, JsonRequestBehavior.AllowGet);
//    }