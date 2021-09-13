using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ProjectAssigned.Models;
using System.Net;
using System.Data.Entity;

namespace ProjectAssigned.Controllers
{
    public class CreateDeveloperController : Controller
    {
       

        ProjectAssignedEntities db = new ProjectAssignedEntities();
        string extension;
        string fileName;
        string uploadUrl;
        
        // GET: CreateDeveloper

        public ActionResult DeveloperList()
        {
            return View(db.CreateDevelopers.ToList());
        }
        public ActionResult AddDeveloper()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult AddDeveloper( CreateDeveloper create, HttpPostedFileBase Dp, HttpPostedFileBase cvdata)
        {

          
            try
            {

               // upload cv file
                if (cvdata != null)
                {
                    extension = Path.GetExtension(cvdata.FileName);
                    if (extension.ToLower() == ".doc" || extension.ToLower() == ".docx" || extension.ToLower() == ".txt")
                    {
                        if (cvdata.ContentLength < 1000000)
                        {
                            fileName = Guid.NewGuid().ToString() + extension;
                            uploadUrl = Server.MapPath("~/Content/Filesdata/Cv/");
                            create.Cv = "~/Content/Filesdata/Cv/" + fileName;
                            cvdata.SaveAs(Path.Combine(uploadUrl, fileName));
                        }
                        else
                        {
                            ModelState.AddModelError("", "file size must be less than 2 mb");

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "File must b doc,docx and text");
                        return View(create);
                    }
                }
                //Dp Upload code
                if (Dp != null)
                {
                    extension = Path.GetExtension(Dp.FileName);
                    if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                    {
                        if (Dp.ContentLength < 500000)
                        {
                            fileName = Guid.NewGuid().ToString() + extension;
                            uploadUrl = Server.MapPath("~/Content/Filesdata/Images/");
                            create.Image = "~/Content/Filesdata/Images/" + fileName;
                            Dp.SaveAs(Path.Combine(uploadUrl, fileName));

                        }
                        else
                        {
                            ModelState.AddModelError("", "Image must b less than 5 kb");
                            return View(create);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "image must b png jpg and jpeg");
                        return View(create);
                    }
                }

               // add record in the Db

                db.CreateDevelopers.Add(create);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("DeveloperList");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(create);

            



        }



        //Edit Get
        public ActionResult EditDeveloper(int?id)
        { 
              CreateDeveloper create = new CreateDeveloper();
             
        
            //if(id==null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            if (id != null)
            {
              
            create = db.CreateDevelopers.Where(model => model.Developer_Id == id).FirstOrDefault<CreateDeveloper>();
                
            }

            return View(create);
        }
        [HttpPost]
        public ActionResult EditDeveloper(CreateDeveloper create, HttpPostedFileBase Dp, HttpPostedFileBase cvdata)
        {
           
            try
                {
                    //upload cv file
                    if (cvdata != null)
                    {
                        extension = Path.GetExtension(cvdata.FileName);
                        if (extension.ToLower() == ".doc" || extension.ToLower() == ".docx" || extension.ToLower() == ".txt")
                        {
                            if (cvdata.ContentLength < 1000000)
                            {
                                fileName = Guid.NewGuid().ToString() + extension;
                                uploadUrl = Server.MapPath("~/Content/Filesdata/Cv/");
                                create.Cv = "~/Content/Filesdata/CV/" + fileName;
                                if (!String.IsNullOrEmpty(create.Image))
                                {
                                    if (System.IO.File.Exists(uploadUrl + "/" + create.Cv))
                                    {
                                        System.IO.File.Delete(uploadUrl + "/" + create.Cv);

                                    }
                                }
                                cvdata.SaveAs(Path.Combine(uploadUrl, fileName));
                               
                            }
                            else
                            {
                                ModelState.AddModelError("", "file must b less than 1 Mb");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "File  must b doc , docx, txt");
                        }
                    }
                    //Dp Upload code
                    if (Dp != null)
                    {
                        extension = Path.GetExtension(Dp.FileName);
                        if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                        {
                            if (Dp.ContentLength < 500000)
                            {
                                
                                uploadUrl = Server.MapPath("~/Content/Filesdata/Images/");
                                fileName = Guid.NewGuid().ToString() + extension;
                                create.Image = "~/Content/Filesdata/Images/" + fileName;

                                if (!String.IsNullOrEmpty(create.Image))
                                {
                                    if (System.IO.File.Exists(uploadUrl + "/" + create.Image))
                                    {
                                        System.IO.File.Delete(uploadUrl + "/" + create.Image);

                                    }
                                }
                                
                                Dp.SaveAs(Path.Combine(uploadUrl, fileName));

                            }
                            else
                            {
                                ViewBag.message = "Picture size must be less than 2 mb";
                                return View(" AddDeveloper");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Picture must be png, jpg or jpeg");
                           
                            
                        }
                    }

                //add record in the Db
              
                    db.Entry(create).State = EntityState.Modified;
                    db.SaveChanges();
                   
                    return RedirectToAction("DeveloperList");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("","Somthing went wrong");
                }
          
           
            
           return View(create);
        }

        public JsonResult IsUserExists(string Username, string UserPassword, string Email, string Phone, string prevemail,string prevpass,string prevname, string prephone)
        {
            try { 
            if(Username== prevname||Email==prevemail||UserPassword==prevpass||Phone==prephone)
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            return Json(!db.CreateDevelopers.Any(x => x.Username == Username || x.UserPassword == UserPassword || x.Email == Email || x.Phone == Phone),JsonRequestBehavior.AllowGet);
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            
            }
            catch(Exception)
            {

                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }


    }
}