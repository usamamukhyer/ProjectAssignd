using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectAssigned.Models;

namespace ProjectAssigned.Controllers
{
    public class AssignProjectController : Controller
    {
        //ProjectAssignedEntities db = new ProjectAssignedEntities();
        //// GET: Admin
        //public ActionResult Index()
        //{

        //    List<CreateProject> model = new List<CreateProject>();
        //    model = db.CreateProjects.ToList();

        //    return View(model);



        //}

        //public ActionResult AddProject()
        //{
        //    CreateProject model = new CreateProject();

        //    //for dropdown values of status list
        //    List<string> Statuslist = new List<string>();
        //    Statuslist.Add("Success");
        //    Statuslist.Add("Fail");
        //    Statuslist.Add("Pending");
        //    Statuslist.Add("In Progress");
        //    ViewBag.Status = new SelectList(Statuslist);

        //    //for dropdown values Project Type  list 

        //    List<string> Type = new List<string>();
        //    Type.Add("Foreign");
        //    Type.Add("Local");

        //    ViewBag.ProjectType = new SelectList(Type);



        //    //query for Developer list
        //    ViewBag.Developer_Id = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname");


        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddProject(CreateProject model)
        //{
        //   try { 
            
        //        //for the file  upload
        //        if (Request.Files != null)
        //        {
        //            HttpFileCollectionBase files = Request.Files;

        //            foreach (string file in files)
        //            {
        //                try
        //                {
        //                   HttpPostedFileBase postedfile = files[file];
        //                    string extension = Path.GetExtension(postedfile.FileName).ToLower();

        //                    string filecontain = ".txt,.doc,.pdf";
        //                    if (extension != string.Empty)
        //                    {
                               
        //                        if (filecontain.Contains(extension))
        //                        {
                                   
        //                            string path = Server.MapPath("~/Content/Filesdata/Projectfiles/");
        //                            model.Fileuploads = path.FetchUniquePath(postedfile.FileName);
        //                            postedfile.SaveAs(path + "/" + model.Fileuploads);
        //                        }
        //                        else
        //                        {
        //                            ModelState.AddModelError("", "Only txt, doc and pdf files are allowed");
        //                            return View(model);
        //                        }


        //                    }

        //                }
        //                catch (Exception ex)
        //                {

        //                    ModelState.AddModelError("", ex.Message);
        //                    return View(model);
        //                }


        //            }


        //        }



        //        db.CreateProjects.Add(model);
        //        db.SaveChanges();
        //        ModelState.Clear();

        //        return RedirectToAction("Index");
        //   }
        //    catch(Exception)
        //    {
        //        ModelState.AddModelError("", "somthing went wrong");

        //    }
        //        return View(model);
            

        //}


        ////edit record of create table
        ////Get METHOD FOR THE EDITPROJECT
        //public ActionResult Editproject(int?id)
        //{
        //    CreateProject model = new CreateProject();

        //    List<string> Statuslist = new List<string>();
        //    Statuslist.Add("Success");
        //    Statuslist.Add("Fail");
        //    Statuslist.Add("Pending");
        //    Statuslist.Add("In Progress");


        //    //for dropdown values Project Type  list 

        //    List<string> Type = new List<string>();
        //    Type.Add("Foreign");
        //    Type.Add("Local");

        //    if (id != null)
        //    {
                
        //        model = db.CreateProjects.Where(m => m.Project_Id== id).FirstOrDefault<CreateProject>();
        //        ViewBag.Status = new SelectList(Statuslist, model.Status);
        //        ViewBag.ProjectType = new SelectList(Type, model.ProjectType);
        //        ViewBag.Developer_Id = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname", model.Developer_Id);

        //    }
        //    else
        //    {
        //        ViewBag.Status = new SelectList(Statuslist);
        //        ViewBag.ProjectType = new SelectList(Type);
        //        ViewBag.Developer_Id = new SelectList(db.CreateDevelopers);
        //    }

        //    return View(model);
        //}


        ////http method post
        //[HttpPost]
        //public ActionResult Editproject(CreateProject model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        List<string> Statuslist = new List<string>();
        //        Statuslist.Add("Success");
        //        Statuslist.Add("Fail");
        //        Statuslist.Add("Pending");
        //        Statuslist.Add("In Progress");


        //        //for dropdown values Project Type  list 

        //        List<string> Type = new List<string>();
        //        Type.Add("Foreign");
        //        Type.Add("Local");
        //        ViewBag.Status = new SelectList(Statuslist);
        //        ViewBag.ProjectType = new SelectList(Type);
        //        ViewBag.Developer_Id = new SelectList(db.CreateDevelopers);

        //        if (Request.Files != null)
        //        {
        //            HttpFileCollectionBase files = Request.Files;

        //            foreach (string file in files)
        //            {
        //                try
        //                {
        //                    HttpPostedFileBase postedfile = files[file];
        //                    string extension = Path.GetExtension(postedfile.FileName).ToLower();                        
        //                    string filecontain = ".txt,.doc,.pdf";
        //                    if (extension != string.Empty)
        //                    {
        //                        if (filecontain.Contains(extension))
        //                        { 
        //                            string path = Server.MapPath("~/Content/Filesdata/Projectfiles/");
        //                            if (!String.IsNullOrEmpty(model.Fileuploads))
        //                            {
        //                                if (System.IO.File.Exists(path + "/" + model.Fileuploads))
        //                                {
        //                                    System.IO.File.Delete(path + "/" + model.Fileuploads);

        //                                }
        //                            }
        //                            model.Fileuploads = path.FetchUniquePath(postedfile.FileName);
        //                            postedfile.SaveAs(path + "/" + model.Fileuploads);
        //                        }
        //                        else
        //                        {
        //                            ModelState.AddModelError("", "Only txt, doc and pdf files are allowed");
        //                            return View(model);
        //                        }


        //                    }

        //                }
        //                catch (Exception ex)
        //                {

        //                    ModelState.AddModelError("", ex.Message);
        //                    return View(model);
        //                }


        //            }


        //        }



        //        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }

        //    return View(model);

        //}
    }
}
