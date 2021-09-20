using ProjectAssigned.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAssigned.Controllers
{
    public class FeedbackController : Controller
    {
        ProjectAssignedEntities db = new ProjectAssignedEntities();
        public ActionResult Index()
        {

            List<ProjectFeedback> model = new List<ProjectFeedback>();
            model = db.ProjectFeedbacks.ToList();

            return View(model);
        }


        // GET: Feedback
        public ActionResult AssignFeedback()
        {
            
            ViewBag.Developer_Id = new SelectList(new List<CreateDeveloper>(), "Developer_Id", "Firstname", null);
            ViewBag.Project_Id = new SelectList(db.CreateProjects.OrderByDescending(m=> m.ProjectTitle), "Project_Id", "ProjectTitle", null);
            return View();
        }

        [HttpPost]
        public ActionResult AssignFeedback(ProjectFeedback model)
        {
            
           
           
                db.ProjectFeedbacks.Add(model);
                db.SaveChanges();
                ModelState.Clear();


           

            return RedirectToAction ("AssignFeedback");
        }

        //http get for 
        public ActionResult EditFeedback(int?id)
        {
           ProjectFeedback model = new ProjectFeedback();
            if (id!=null)
            {
               

                model = db.ProjectFeedbacks.Where(x => x.FeedId == id).FirstOrDefault<ProjectFeedback>();
               // Query to show developer against in edit mode
                ViewBag.Developer_Id = new SelectList(db.CreateDevelopers.OrderByDescending(x=> x.Firstname), "Developer_Id", "Firstname",model.Developer_Id);
                // Query to show project  in edit mode
                ViewBag.Project_Id = new SelectList(db.CreateProjects.OrderByDescending(m => m.ProjectTitle), "Project_Id", "ProjectTitle", model.Project_Id);



            }
            return View(model);
        }

        [HttpPost]
        //edit of the feedback
        public ActionResult EditFeedback(ProjectFeedback model)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Somthing wen wrong please contact to your Administrator");
            }
            return View(model);
        }



        public JsonResult GetDeveloper(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var  project= db.CreateProjects.AsNoTracking().Where(x => x.Project_Id == id).FirstOrDefault();
            var developer=   db.CreateDevelopers.Where(x => x.Developer_Id == project.Developer_Id).ToList();


            return Json(developer, JsonRequestBehavior.AllowGet);


        }
    }
}