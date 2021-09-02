using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAssigned.Controllers
{
    public class LoginModuleController : Controller
    {
        // GET: LoginModule
        public ActionResult Login()
        {
            
            return View();
        }

        //
      
      

       
        
        public ActionResult Register()
        {
            return View();
        }

       
       

        //
       
        public ActionResult ConfirmEmail()
        {
            return View(); 
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

       

       
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return  View() ;
        }

      
       

       
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        
        
       
       
      
        
        public ActionResult LogOff()
        {
            
            return View();
        }
        public ActionResult ChangePassword()
        {

            return View();
        }


    }
}
 