using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectAssigned.Models;

namespace ProjectAssigned.Controllers
{
    public class AssignProjectController : Controller
    {
        ProjectAssignedEntities db = new ProjectAssignedEntities();
        // GET: Admin
        public ActionResult AddProject(int?id)
        {
            CreateProject model = new CreateProject();

            //for dropdown values of status list
            List<string>Statuslist= new List<string>();
            Statuslist.Add("Success");
            Statuslist.Add("Fail");
            Statuslist.Add("Pending");
            Statuslist.Add("In Progress");
            ViewBag.Status = new SelectList(Statuslist,model.Status);



            //query for Developer list
            ViewBag.Developer_Id = new SelectList(db.CreateDevelopers, "Developer_Id", "Firstname");


            return View(model);
        }

        [HttpPost]
        public ActionResult AddProject(CreateProject create, HttpPostedFileBase file)
        {
         

            return View(create);
        }


    }
}