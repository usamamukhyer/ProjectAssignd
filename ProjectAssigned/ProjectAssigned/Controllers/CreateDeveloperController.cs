using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ProjectAssigned.Models;

namespace ProjectAssigned.Controllers
{
    public class CreateDeveloperController : Controller
    {

        ProjectAssignedEntities db = new ProjectAssignedEntities();
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
        public ActionResult AddDeveloper(HttpPostedFileBase Dp, HttpPostedFileBase cvdata   , CreateDeveloper create)
        {
            try
            {
                
                    if(Dp!=null)
                    {
                        string dpname = Path.GetFileName(Dp.FileName);
                        string _dpname = DateTime.Now.ToString("yymmssfff") + dpname;
                        string extension = Path.GetFileName(Dp.FileName);
                        string path = Path.Combine(Server.MapPath("~/ Content/Filesdata/Images"),_dpname);
                        create.Image = "~/ Content/Filesdata/Images" + _dpname;
                        if(extension.ToLower()==".jpg"|| extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                        {
                            if (Dp.ContentLength<2000000)
                            {
                                Dp.SaveAs(path);
                                
                            }
                            else
                            {
                                ViewBag.message = "file is to much long";
                            }
                        }


                    }
                    if (cvdata != null)
                    {
                        string data = Path.GetFileName(cvdata.FileName);
                        string _dataname = DateTime.Now.ToString("yymmssfff") + data;
                        string extension = Path.GetFileName(cvdata.FileName);
                        string path = Path.Combine(Server.MapPath("~/ Content/Filesdata/Cv"), _dataname);
                        create.Cv = "~/ Content/Filesdata/Cv" + _dataname; 
                        if (extension.ToLower() == ".txt" || extension.ToLower() == ".doc" || extension.ToLower() == ".pdf")
                        {
                            if (cvdata.ContentLength < 2000000)
                            {
                                cvdata.SaveAs(path);

                            }
                            else
                            {
                                ViewBag.message = "file is to much long";
                            }
                        }


                    
                    db.CreateDevelopers.Add(create);
                    db.SaveChanges();
                    ModelState.Clear();

                    return RedirectToAction(" DeveloperList","CreateDeveloper");
                    

                }

            }
            catch(Exception ex)
            {
                
                ModelState.AddModelError("", "somthing went wrong");
            }

            return View("AddDeveloper");
        }


       
    }
}