using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAssigned.Controllers
{
    public class NewModulesController : Controller
    {
        // GET: NewModules
        public ActionResult NewModuleForm()
        {
            return View();
        }
    }
}