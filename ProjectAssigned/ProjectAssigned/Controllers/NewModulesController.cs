using ProjectAssigned.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAssigned.Controllers
{
    public class NewModulesController : Controller
    {
        ProjectAssignedEntities db = new ProjectAssignedEntities();

        // GET: NewModules
       // public ActionResult Index()
       // {
       //     return View(db.NewModules.ToList());
       // }


       // ///get method of add module
       // public ActionResult AddModule()
       // {
       //     //dropdown values for the Project Status
       //     List<string> statusDrd = new List<string>();
       //     statusDrd.Add("Success");
       //     statusDrd.Add("Fail");
       //     statusDrd.Add("Pending");
       //     statusDrd.Add("In Progress");
       //     ViewBag.Status = new SelectList(statusDrd);

       //     //queries for accessing the data from the data base and shift it into the dropdown fileds
       //     ViewBag.Assign = new SelectList(new List<CreateDeveloper>(), "Developer_Id", "Firstname");
       //     ViewBag.Project_Id = new SelectList(db.CreateProjects.OrderByDescending(m =>m.ProjectTitle), "Project_Id", "ProjectTitle");
       //     ViewBag.Developer_Id = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname");

       //     return View();
       // }

       // //post method of add module
       // [HttpPost]
       // public ActionResult AddModule(NewModule model,HttpPostedFileBase file)
       // {
       //     try {
                
       //         List<string> statusDrd = new List<string>();
       //         statusDrd.Add("Success");
       //         statusDrd.Add("Fail");
       //         statusDrd.Add("Pending");
       //         statusDrd.Add("In Progress");
       //         ViewBag.Status = new SelectList(statusDrd);
       //         ViewBag.Developer_Id = new SelectList(new List<CreateDeveloper>(), "Developer_Id", "Firstname");
       //         ViewBag.Project_Id = new SelectList(db.CreateProjects.OrderByDescending(m => m.ProjectTitle), "Project_Id", "ProjectTitle");
       //         ViewBag.Assign = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname",model.Developer_Id);


       //         string extension = Path.GetExtension(file.FileName);
       //     if (extension.ToLower() == ".doc" || extension.ToLower() == ".docx" || extension.ToLower() == ".txt")
       //     {
       //         if (file.ContentLength < 1000000)
       //         {
       //           string  fileName = Guid.NewGuid().ToString() + extension;
       //            string uploadUrl = Server.MapPath("~/Content/Filesdata/Cv/");
       //             model.fileupload = "~/Content/Filesdata/Cv/" + fileName;
       //             file.SaveAs(Path.Combine(uploadUrl, fileName));
       //         }
       //         else
       //         {
       //             ModelState.AddModelError("", "file size must be less than 2 mb");

       //         }
       //     }
       //     else
       //     {
       //         ModelState.AddModelError("", "File must b doc,docx and text");
       //         return RedirectToAction(" AddModule");
       //     }
       //     }
       //     catch(Exception)
       //     {
       //         ModelState.AddModelError("", "Something went wrong");
       //     }
       //     db.NewModules.Add(model);
       //     db.SaveChanges();
       //     ModelState.Clear();

       //     return View("AddModule");
       // }
       // //Get Method
       // public ActionResult EditModule(int?id)
       // {
       //     NewModule model = new NewModule();
       //     List<string> statusDrd = new List<string>();
       //     statusDrd.Add("Success");
       //     statusDrd.Add("Fail");
       //     statusDrd.Add("Pending");
       //     statusDrd.Add("In Progress");
       //     if(id!=null)
       //     {
       //         model = db.NewModules.Where(x => x.ModuleId == id).FirstOrDefault<NewModule>();

       //     ViewBag.Status = new SelectList(statusDrd,model.Status);
       //     ViewBag.Developer_Id = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname",model.CreateDeveloper.Developer_Id);
       //     ViewBag.Project_Id = new SelectList(db.CreateProjects.OrderByDescending(m => m.ProjectTitle), "Project_Id", "ProjectTitle",model.Project_Id);
       //     ViewBag.Assign = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname", model.Assign);
       //     }
       //     return View(model);

       // }

       // //Post method
       // [HttpPost]
       // public ActionResult EditModule(NewModule model, HttpPostedFileBase file)
       // {
       //     try
       //     {

       //         List<string> statusDrd = new List<string>();
       //         statusDrd.Add("Success");
       //         statusDrd.Add("Fail");
       //         statusDrd.Add("Pending");
       //         statusDrd.Add("In Progress");
       //         ViewBag.Status = new SelectList(statusDrd);
       //         ViewBag.Developer_Id = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname");
       //         ViewBag.Project_Id = new SelectList(db.CreateProjects.OrderByDescending(m => m.ProjectTitle), "Project_Id", "ProjectTitle");
       //         ViewBag.Assign = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname", model.Developer_Id);


       //         string extension = Path.GetExtension(file.FileName);
       //         if (extension.ToLower() == ".doc" || extension.ToLower() == ".docx" || extension.ToLower() == ".txt")
       //         {
       //             if (file.ContentLength < 1000000)
       //             {
       //                 string fileName = Guid.NewGuid().ToString() + extension;
       //                 string uploadUrl = Server.MapPath("~/Content/Filesdata/Cv/");
       //                 model.fileupload = "~/Content/Filesdata/Cv/" + fileName;
       //                 file.SaveAs(Path.Combine(uploadUrl, fileName));
       //             }
       //             else
       //             {
       //                 ModelState.AddModelError("", "file size must be less than 2 mb");

       //             }
       //         }
       //         else
       //         {
       //             ModelState.AddModelError("", "File must b doc,docx and text");
       //             return RedirectToAction(" AddModule");
       //         }
       //     }
       //     catch (Exception)
       //     {
       //         ModelState.AddModelError("", "Something went wrong");
       //     }
       //     db.Entry(model).State = System.Data.Entity.EntityState.Modified;
       //     db.SaveChanges();
       //     ModelState.Clear();

       //     return View("Index");
       // }

       // public JsonResult GetDeveloper(int id)
       //{
           
       //     db.Configuration.ProxyCreationEnabled = false;
       //     var project = db.CreateProjects.AsNoTracking().Where(x => x.Project_Id == id).FirstOrDefault();
       //     var developer = db.CreateDevelopers.Where(x => x.Developer_Id == project.Developer_Id).ToList();

       //     return Json(developer, JsonRequestBehavior.AllowGet);

       // }
    }
}