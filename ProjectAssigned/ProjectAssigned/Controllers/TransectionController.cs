using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectAssigned.Models;
namespace ProjectAssigned.Controllers
{
    public class TransectionController : Controller
    {
        ProjectAssignedEntities db = new ProjectAssignedEntities();
        // GET: Transection
        public ActionResult Index()
        {
            ViewBag.totalIncome = db.cash_In().First();
            ViewBag.totalSpent= db.cash_Out().First().ToString();
            ViewBag.Remaining = db.remaining_Cash().First().ToString();

            return View(db.Transections.ToList());
        }

        //Http get and post method for the adding of the transection
        #region Addtransection
        public ActionResult AddTransection()
        {
            
           #region CashType
             List<string> cashType = new List<string>();
            cashType.Add("CashIn");
            cashType.Add("CashOut");
            ViewBag.CashType = new SelectList(cashType);

            
            #endregion
            //list for the income resource
            List<string> collectFrom = new List<string>();
            collectFrom.Add("From forign projects");
            collectFrom.Add("From Local projects");
            ViewBag.IncomeCollectFrom = new SelectList(collectFrom);


            //list for the spent the resources
            List<string> spentTo= new List<string>();
            spentTo.Add("Drinking Water Bottles");
            spentTo.Add("Swiper");
            spentTo.Add("Office Repairing");
            spentTo.Add("Office Rent");
            spentTo.Add("Office Accesories");
            spentTo.Add("Office Electricity Bill");
            spentTo.Add("Office Internet Bill");
            spentTo.Add("Office Meal");

            ViewBag.IncomeSpentTo = new SelectList(spentTo);
            return View();
        }
        //post method of the add transection 
        [HttpPost]
        public ActionResult AddTransection(Transection model)
        {
           
               
                    #region ViewBag
                    List<string> cashType = new List<string>();
             cashType.Add("CashIn");
             cashType.Add("CashOut");
             ViewBag.CashType = new SelectList(cashType);


            #endregion
            //list for the income resource
            List<string> collectFrom = new List<string>();
            collectFrom.Add("From forign projects");
            collectFrom.Add("From Local projects");
            ViewBag.IncomeCollectFrom = new SelectList(collectFrom);


            //list for the spent the resources
            List<string> spentTo = new List<string>();
            spentTo.Add("Drinking Water Bottles");
            spentTo.Add("Swiper");
            spentTo.Add("Office Repairing");
            spentTo.Add("Office Rent");
            spentTo.Add("Office Accesories");
            spentTo.Add("Office Electricity Bill");
            spentTo.Add("Office Internet Bill");
            spentTo.Add("Office Meal");
            ViewBag.IncomeSpentTo = new SelectList(spentTo);

            try
            {

                db.Transections.Add(model);
               db.SaveChanges();
               ModelState.Clear();
                return RedirectToAction("Index");

            }
            catch(Exception)
            {
                ModelState.AddModelError("", "somthing is went wrong");
                return View(model);
            }
        }
        #endregion
        //get and post method of Edit
        #region EditTransection
        //http get
        public ActionResult EditTransection(int?id)
        {
            Transection model = new Transection();
            

            #region CashType
            List<string> cashType = new List<string>();
            cashType.Add("CashIn");
            cashType.Add("CashOut");
            ViewBag.CashType = new SelectList(cashType);


            #endregion
            //list for the income resource
            List<string> collectFrom = new List<string>();
            collectFrom.Add("From forign projects");
            collectFrom.Add("From Local projects");
            ViewBag.IncomeCollectFrom = new SelectList(collectFrom);


            //list for the spent the resources
            List<string> spentTo = new List<string>();
            spentTo.Add("Drinking Water Bottles");
            spentTo.Add("Swiper");
            spentTo.Add("Office Repairing");
            spentTo.Add("Office Rent");
            spentTo.Add("Office Accesories");
            spentTo.Add("Office Electricity Bill");
            spentTo.Add("Office Internet Bill");
            spentTo.Add("Office Meal");

            
            if(id!=null)
            {
                model = db.Transections.Where(x => x.TransecId == id).FirstOrDefault<Transection>();
                ViewBag.CashType = new SelectList(cashType,model.CashType);
                ViewBag.IncomeCollectFrom = new SelectList(collectFrom,model.IncomeCollectFrom);
                ViewBag.IncomeSpentTo = new SelectList(spentTo,model.IncomeSpentTo);

            }
            else
            {
                ViewBag.CashType = new SelectList(cashType);
                ViewBag.IncomeCollectFrom = new SelectList(collectFrom);
                ViewBag.IncomeSpentTo = new SelectList(spentTo);
            }
            return View(model);
        }
        #endregion
    }
}