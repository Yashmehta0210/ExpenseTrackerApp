using ExpenseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker1.Controllers
{
    /*[Authorize]*/
    public class DashboardController : Controller
    {
       
        // GET: Dashboard
        public ActionResult Dashboard_Expense()
        {

            return View();
        }
    }
}