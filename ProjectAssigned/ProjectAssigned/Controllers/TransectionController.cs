using ProjectAssigned.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic;
namespace ProjectAssigned.Controllers
{
    public class TransectionController : Controller
    {
        ProjectAssignedEntities db = new ProjectAssignedEntities();
        // GET: Transection
        public ActionResult Index()
        {
            return View();

        }
        public JsonResult GetList()
        {
            //server side processing data
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirec = Request["order[0][dir]"];
            
            List<TransectionViewModel> list= db.Transections.Select(x =>new TransectionViewModel { 
            TransecId=x.TransecId,
            CashType=x.CashType,
            IncomeCollectFrom=x.IncomeCollectFrom,
            IncomeSpentTo=x.IncomeSpentTo,
            Amount=x.Amount,
            Date=x.Date.ToString(),
            Discription=x.Discription
            } ).ToList();
            int totalRows = list.Count;
            int filterRecords = list.Count;
            if(!string.IsNullOrEmpty(searchValue))
            {

                list = list.Where(x =>
                
                x.CashType.ToLower().Contains(searchValue.ToLower()) || /*/*x.IncomeCollectFrom.ToLower().Contains(searchValue.ToLower()) ||*/  x.Discription.ToLower().Contains(searchValue.ToLower()) || x.Date.ToString().Contains(searchValue.ToLower())).ToList<TransectionViewModel>();
            }
            //sorting of the data table
            list = list.OrderBy(sortColumn + " " + sortDirec).ToList<TransectionViewModel>();
            //paging of the datatable
            list = list.Skip(start).Take(length).ToList<TransectionViewModel>();
            return Json(new {data=list,draw=Request["draw"],recordsTotal=totalRows,recordsFiltered=filterRecords}, JsonRequestBehavior.AllowGet);
        }

      
        //public ActionResult List()
        //{
        //    var data = db.Transections.OrderBy(a => a.CashType).ToList();
        //    return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        //}



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
                model = db.Transections.Where(x => x.TransecId == id).FirstOrDefault<Transection>();
                ViewBag.CashType = new SelectList(cashType, model.CashType);
                ViewBag.IncomeCollectFrom = new SelectList(collectFrom, model.IncomeCollectFrom);
                ViewBag.IncomeSpentTo = new SelectList(spentTo, model.IncomeSpentTo);
            }
            return View(model);
        }
        #endregion
    }
}