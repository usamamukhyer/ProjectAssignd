using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ProjectAssigned.Models;
using System.Net;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


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
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
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
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                        model.Cv = fileName;
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

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, Address = model.Address, FirstName = model.FirstName, LastName = model.LastName, IsActive = model.IsActive, PhoneNumber = model.PhoneNumber, Experience = model.Experience, Photo = model.Photo, CV = model.Cv, JoinDate = model.JoinDate, Salary = model.Salary, Bio = model.Bio, Designation = model.Designation };
            var result = UserManager.Create(user, model.PasswordHash);
            if (result.Succeeded)
            {
               
                //TempData["Message"] = "Success : Doctor has been added successfully";
                //string profileName = user.FirstName + " " + (String.IsNullOrEmpty(user.LastName) ? string.Empty : user.LastName);
                //(new GenericModel()).FetchUserProfile().activityLog("Doctor creation", "<b>Profile of '" + profileName + "'</b> has been created", user.Id, "AspNetUser");
                return RedirectToAction("AddDeveloper");
            }
            else
            {
                ModelState.AddModelError("", "Passwords must have at least one non letter or digit character.Passwords must have at least one digit('0' - '9').Passwords must have at least one uppercase('A' - 'Z').");
                return View(model);
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
    
            //return view();

    
    



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