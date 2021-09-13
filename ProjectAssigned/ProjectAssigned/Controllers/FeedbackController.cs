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
            
            ViewBag.developerFiedls = new SelectList(new List<CreateDeveloper>(), "Developer_Id", "Firstname", null);
            ViewBag.projectFields = new SelectList(db.CreateProjects.OrderByDescending(m=> m.ProjectTitle), "Project_Id", "ProjectTitle", null);
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

        public ActionResult EditFeedback(int?id)
        {
           ProjectFeedback model = new ProjectFeedback();
            if(id!=null)
            {
                model = db.ProjectFeedbacks.Where(x => x.FeedId == id).FirstOrDefault<ProjectFeedback>();
                ViewBag.developerFiedls = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname", model.Developer_Id);
                ViewBag.projectFields = new SelectList(db.CreateProjects.OrderByDescending(m => m.ProjectTitle), "Project_Id", "ProjectTitle", model.Project_Id);
            }
            return View(model);
        }



        public JsonResult GetDeveloper(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var model = db.CreateProjects.AsNoTracking().Where(x => x.Project_Id == id).FirstOrDefault();
            var developer=   db.CreateDevelopers.Where(x => x.Developer_Id == model.Developer_Id).ToList();


            return Json(developer, JsonRequestBehavior.AllowGet);


        }
    }
}